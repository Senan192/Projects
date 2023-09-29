//senan yatigammana G21017409
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace SmartBuilding
{

    public class BuildingController
    {
        private string buildingID;
        private string currentState;

       
        public BuildingController(string id)
        {
            string buildID = id.ToLower();
            SetBuildingID(buildID);
            currentState = "out of hours";
        }


        public BuildingController(string id, string startState)
        {
            string buildID = id.ToLower();
            SetBuildingID(buildID);
            string unverifiedState = startState.ToLower();
            if ((unverifiedState == "open") || (unverifiedState == "closed") || (unverifiedState == "out of hours"))
            {
                currentState = unverifiedState;
            }
            else
            {
                throw new ArgumentException("Argument Exception: BuildingController can only be initialised to the following states 'open', 'closed', 'out of hours'");   
            }
        }

        ILightManager LightManager;
        IFireAlarmManager FireAlarmManager;
        IDoorManager DoorManager;
        IWebService WebServiceManager;
        IEmailService EmailServiceManager;

        public BuildingController(string id, ILightManager iLightManager, IFireAlarmManager iFireAlarmManager,
        IDoorManager iDoorManager, IWebService iWebService, IEmailService iEmailService)
        {
            string buildID = id.ToLower();
            SetBuildingID(buildID);

            LightManager = iLightManager;
            FireAlarmManager = iFireAlarmManager;
            DoorManager = iDoorManager;
            WebServiceManager = iWebService;
            EmailServiceManager = iEmailService;
            currentState = "out of hours";
        }

        public void SetBuildingID(string buildID)
        {
            buildingID = buildID.ToLower();
        }

        public string GetBuildingID()
        {
            return buildingID;
        }

        public string GetCurrentState()
        {
            return currentState;
        }

        string previousState = " ";
        public bool SetCurrentState(string state)
        {
            //if state is changed to the same state, it will remain in the first state and return true for alarm states
            //this is because, if fire alarm is changed to fire alarm again, the history state becomes the first instance of fire alarm
            //this will create problems when moving back
            bool output = false;
            //to implement the state change according to the diagram, ive implemented it as a case of if else caluses
            //this is the pattern for the whole set state function
            if (state == "closed")
            {
                //case of moving from alarm state to normal
                if ((state == "closed") && (previousState == "closed") && ((currentState == "fire drill") || (currentState == "fire alarm")))
                {
                    currentState = "closed";
                    output= true;
                    DoorManager.LockAllDoors();
                    LightManager.SetAllLights(false);
                }

                else if ((state == "closed") && ((currentState == "out of hours") || (currentState == "closed")))
                {

                    currentState = "closed";
                    output =true;
                    DoorManager.LockAllDoors();
                    LightManager.SetAllLights(false);


                }
                return output;
            }

            else if(state=="out of hours")
            {
                if ((state == "out of hours") && (previousState == "out of hours") && ((currentState == "fire drill") || (currentState == "fire alarm")))
                {
                    currentState = "out of hours";
                    output = true;
                }

                else if ((state == "out of hours") && ((currentState == "closed") || (currentState == "open") || (currentState == "out of hours")))
                {

                    currentState = "out of hours";
                    output = true;

                }
                return output;
            }

            else if (state == "open")
            {
                if ((state == "open") && (previousState == "open") && ((currentState == "fire drill") || (currentState == "fire alarm")))
                {
                    if (DoorManager.OpenAllDoors() == true)
                    {
                        currentState = "open";
                        output = true;
                    }
                    else if (DoorManager.OpenAllDoors() == false)
                    {
                        output = false;
                    }

                }

                else if ((state == "open") && ((currentState == "out of hours") || (currentState == "open")))
                {
                    if (DoorManager.OpenAllDoors() == true)
                    {
                        currentState = "open";
                        output = true;

                    }
                    else if (DoorManager.OpenAllDoors() == false)
                    {
                        output = false;
                    }


                }

                return output;


            }

            else if (state == "fire drill")
            {
                  if ((state == "fire drill") && (currentState == "fire drill"))
                {
                    output= true;
                   
                }

                else if (state == "fire drill")
                {
                    previousState = currentState;
                    currentState = "fire drill";
                    output = true;

                }
                return output;
            }
            else if (state == "fire alarm")
            {
                if ((state == "fire alarm") && (currentState == "fire alarm"))
                {
                    output = true;
                    FireAlarmManager.SetAlarm(true);
                    DoorManager.OpenAllDoors();
                    LightManager.SetAllLights(true);
                    try
                    {
                        WebServiceManager.LogFireAlarm("fire alarm");
                    }
                    catch(InvalidOperationException ex)
                    {
                        EmailServiceManager.SendMail("smartbuilding@uclan.ac.uk", "failed to log alarm", ex.Message);
                    }
                    

                }
              
                else if (state == "fire alarm")
                {
                    previousState = currentState;
                    currentState = "fire alarm";
                    output = true;
                    FireAlarmManager.SetAlarm(true);
                    DoorManager.OpenAllDoors();
                    LightManager.SetAllLights(true);
                     try
                    {
                        WebServiceManager.LogFireAlarm("fire alarm");
                    }
                    catch(InvalidOperationException ex)
                    {
                        EmailServiceManager.SendMail("smartbuilding@uclan.ac.uk", "failed to log alarm", ex.Message);
                    }

                }
                return output;
            }

            else
            {
                return false;
            }

        }

        public string GetStatusReport()
        {
            //calling the web function is decided on if this bool is true or not
            //that is checked by comparing the message recieved from get status
            bool lights = true;
            bool doors = true;
            bool fireAlarm = true;
            string lightManagerMessage = LightManager.GetStatus();
            if(lightManagerMessage!= "Lights,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,") {
                lights = false;
            }
            string doorManagerMessage = DoorManager.GetStatus();
            if(doorManagerMessage!= "Doors,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,")
            {
                doors = false;
            }
            string fireAlarmManagerMesage = FireAlarmManager.GetStatus();
            if(fireAlarmManagerMesage != "FireAlarm,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,")
            {
                fireAlarm = false;
            }


            if ((lights == false) && (fireAlarm == false) && (doors == false))
            {
                WebServiceManager.LogEngineerRequired("Lights,Doors,FireAlarm");
            }
            else if ((lights == false) && (doors == false))
            {
                WebServiceManager.LogEngineerRequired("Lights,Doors");
            }
            else if ((doors == false) && (fireAlarm == false))
            {
                WebServiceManager.LogEngineerRequired("Doors,FireAlarm");
            }
            else if ((lights == false) && (fireAlarm == false))
            {
                WebServiceManager.LogEngineerRequired("Lights,FireAlarm");
            }
            else if (lights==false) {
                WebServiceManager.LogEngineerRequired("Lights");
            }
            else if(doors==false)
            {
                WebServiceManager.LogEngineerRequired("Doors");
            }
            else if(fireAlarm==false)
            {
                WebServiceManager.LogEngineerRequired("FireAlarm");
            }
           
            return lightManagerMessage+doorManagerMessage+fireAlarmManagerMesage;
        }


    }
}