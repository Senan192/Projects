//senan yatigammana G21017409
using NSubstitute;
using NUnit.Framework;
using SmartBuilding;
using System;


namespace SmartBuildingTests
{
    [TestFixture]
    public class BuildingControllerTests
    {

        public BuildingController _buildingController;

        //using NSubstitute to create mock objects
        IFireAlarmManager FireAlarmManager = Substitute.For<IFireAlarmManager>();
        IFireAlarmManager FireAlarmManagerV2 = Substitute.For<IFireAlarmManager>();
        ILightManager LightManager = Substitute.For<ILightManager>();
        ILightManager LightManagerV2 = Substitute.For<ILightManager>();
        IDoorManager DoorManager = Substitute.For<IDoorManager>();
        IDoorManager DoorManagerV2 = Substitute.For<IDoorManager>();
        IWebService WebService = Substitute.For<IWebService>();
        IEmailService EmailService = Substitute.For<IEmailService>();

        [SetUp]
        public void setup()
        {
            //V2 -> return type that returns a fault/false/not the normal flow
            LightManager.GetStatus().Returns("Lights,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,");
            LightManagerV2.GetStatus().Returns("Lights,OK,OK,OK,OK,OK,FAULT,OK,OK,OK,OK,");
            DoorManager.GetStatus().Returns("Doors,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,");
            DoorManagerV2.GetStatus().Returns("Doors,FAULT,OK,OK,OK,OK,OK,OK,OK,OK,OK,");
            FireAlarmManagerV2.GetStatus().Returns("FireAlarm,OK,FAULT,OK,OK,OK,OK,OK,OK,OK,OK,");
            FireAlarmManager.GetStatus().Returns("FireAlarm,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,");
            DoorManager.OpenAllDoors().Returns(true);
            DoorManagerV2.OpenAllDoors().Returns(false);
            DoorManager.LockAllDoors().Returns(true);
            DoorManagerV2.LockAllDoors().Returns(false);
        }

        //L1R2
        [TestCase("testbuilding", "testbuilding")]
        [TestCase("test building", "test building")]
        [TestCase("a very long builidng id", "a very long builidng id")]
        public void ReturnbuildingId_When_GetBuilidngIdCalled(string buildingID, string result)
        {
            //Arrange
            var buildingController = new BuildingController(buildingID);

            //Act
            var buildID = buildingController.GetBuildingID();

            //Assert
            Assert.AreEqual(result, buildID);
        }

        //L1R3
        [TestCase("TestBuilding", "testbuilding")]
        [TestCase("Test Building", "test building")]
        [TestCase("TEST BUILDING", "test building")]
        public void ConvertUpperCaseToLowerCase_In_Constructor(string buildingID, string result)
        {
            //Arrange
            var buildingController = new BuildingController(buildingID);

            //Act
            var buildID = buildingController.GetBuildingID();

            //Assert
            Assert.AreEqual(result, buildID);
        }

        //L1R5 & R6
        [TestCase("testbuilding", "out of hours")]
        [TestCase("test building", "out of hours")]
        [TestCase("a very long builidng id", "out of hours")]
        public void ReturnCurrentstate_When_GetCurrentstateCalled(string buildingID, string result)
        {
            //Arrange
            var buildingController = new BuildingController(buildingID);

            //Act
            var currentState = buildingController.GetCurrentState();

            //Assert
            Assert.AreEqual(result, currentState);
        }


        //L1R7
        [TestCase("out of hours", true)]
        [TestCase("closed", true)]
        [TestCase("open", true)]
        [TestCase("fire drill", true)]
        [TestCase("fire alarm", true)]
        [TestCase("pause", false)]
        [TestCase("outOFHours", false)]
        [TestCase("clsed", false)]
        [TestCase("fire truck", false)]
        [TestCase("Open", false)]
        [TestCase("dog", false)]
        [TestCase("cat", false)]
        public void ChangesStateOnlyIfValidString_IsPassed_ToSetStateFunction(string state, bool result)
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);
            
            //Act
            bool setState = buildingController.SetCurrentState(state);

            //Assert
            Assert.AreEqual(result, setState);
        }


        //L2R1
        //out of hours > closed
        [TestCase("out of hours", "closed", true)]
        //closed/open > out of hours
        [TestCase("closed", "out of hours", true)]
        [TestCase("open", "out of hours", true)]
        //out of hours > closed
        [TestCase("out of hours", "open", true)]
        public void StateChangedOnlyAccordingToDiagram_BasedOn_PreviousState_During_NormalOperation(string currentstate, string newState, bool result)
        {
            //Arrange

            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            buildingController.SetCurrentState(currentstate);
            bool setState = buildingController.SetCurrentState(newState);

            //Assert
            Assert.AreEqual(result, setState);
        }

        //L2R1
        //moving to and from fire alarm
        [TestCase("out of hours", "fire alarm", "out of hours", true)]
        [TestCase("open", "fire alarm", "open", true)]
        [TestCase("closed", "fire alarm", "closed", true)]
        [TestCase("out of hours", "fire alarm", "open", false)]
        [TestCase("open", "fire alarm", "closed", false)]
        [TestCase("out of hours", "fire alarm", "closed", false)]

        //moving to and from fire drill
        [TestCase("out of hours", "fire drill", "out of hours", true)]
        [TestCase("open", "fire drill", "open", true)]
        [TestCase("closed", "fire drill", "closed", true)]
        [TestCase("out of hours", "fire drill", "open", false)]
        [TestCase("open", "fire drill", "closed", false)]
        [TestCase("out of hours", "fire drill", "closed", false)]

        public void StateChangedOnlyAccordingToDiagram_ForAlarmStates(string previousState, string currentstate, string newState, bool result)
        {
            //Arrange

            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            buildingController.SetCurrentState(previousState);
            buildingController.SetCurrentState(currentstate);
            bool setState = buildingController.SetCurrentState(newState);

            //Assert
            Assert.AreEqual(result, setState);
        }

        //L2R2
        [TestCase("out of hours", "out of hours", true)]
        [TestCase("open", "open", true)]
        [TestCase("closed", "closed", true)]
        [TestCase("fire alarm", "fire alarm", true)]
        [TestCase("fire drill", "fire drill", true)]

        public void SetstateReturnTrue_If_AttemptedToChangeStateToSameState(string currentstate, string newState, bool result)
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            buildingController.SetCurrentState(currentstate);
            bool setState = buildingController.SetCurrentState(newState);

            //Assert
            Assert.AreEqual(result, setState);
        }

        //L2R2 & L2R1

        [TestCase("open", "fire alarm", "open", true)]
        [TestCase("closed", "fire drill", "closed", true)]

        public void MovingBackToNormalOperation_If_SameStateIsSet(string previousState, string currentstate, string newState, bool result)
        {
            //Arrange

            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            buildingController.SetCurrentState(previousState);
            buildingController.SetCurrentState(currentstate);
            buildingController.SetCurrentState(currentstate);
            bool setState = buildingController.SetCurrentState(newState);

            //Assert
            Assert.AreEqual(result, setState);
        }

        //L2R2 & L2R1
        //since the history state is saved when moving to an alarm, then isnt discared when moving back to the history state, there was a possibility it could cause errors
        //running this test case showed there are no issues
        [TestCase("open", "fire alarm", "open","out of hours", true)]
        [TestCase("closed", "fire drill", "closed","out of hours", true)]
        [TestCase("out of hours", "fire alarm", "out of hours", "out of hours", true)]
        [TestCase("out of hours", "fire alarm", "out of hours", "open", true)]

        public void MovingToAlarmState_ThenMovingBackToSameHistoryState_ThenMovingToAnotherNormalState(string previousState, string currentstate, string newState,string nextNewState, bool result)
        {
            //Arrange

            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            buildingController.SetCurrentState(previousState);
            buildingController.SetCurrentState(currentstate);
            buildingController.SetCurrentState(newState);
            bool setState = buildingController.SetCurrentState(nextNewState);

            //Assert
            Assert.AreEqual(result, setState);
        }

        //L2R3
        //Passing correct values -test for state in lowercase
        [TestCase("buildID", "open", "open")]
        [TestCase("buildID", "closed", "closed")]
        [TestCase("buildID", "out of hours", "out of hours")]
        [TestCase("BUILDID", "OPEN", "open")]
        [TestCase("buildID", "OUT of hours", "out of hours")]
        public void NoExcpetionIsThrown_When_PassingCorrectParametersTo2ndConstructorMethodV1(string buildingID, string state, string stateReturn)
        {
            //Arrange
            var buildingController = new BuildingController(buildingID, state);

            //Act
            var currentstate = buildingController.GetCurrentState();
            //Assert
            Assert.AreEqual(currentstate, stateReturn);

        }

        //L2R3
        //Passing correct values -test for building ID in lowercase
        [TestCase("buildID", "open", "buildid")]
        [TestCase("buildid", "closed", "buildid")]
        [TestCase("BUILDID", "out of hours", "buildid")]
        [TestCase("BUILDID", "OPEN", "buildid")]
        public void NoExcpetionIsThrown_When_PassingCorrectParametersTo2ndConstructorMethodV2(string buildingID, string state, string IDReturn)
        {
            //Arrange
            var buildingController = new BuildingController(buildingID, state);
             
            //Act
            var buildID = buildingController.GetBuildingID();

            //Assert
            Assert.AreEqual(buildID, IDReturn);

        }

        //L2R3
        //passing incorrect values
        //Reference to arguement exception testing code -https://chadgolden.com/blog/unit-testing-exceptions-in-c-sharp
        [TestCase("buildID", "wrong state", "Argument Exception: BuildingController can only be initialised to the following states 'open', 'closed', 'out of hours'")]
        [TestCase("anotherID", "correct state", "Argument Exception: BuildingController can only be initialised to the following states 'open', 'closed', 'out of hours'")]
        [TestCase("ID", "over", "Argument Exception: BuildingController can only be initialised to the following states 'open', 'closed', 'out of hours'")]

        public void ThrowArguementException_If_InvalidstatePassedToConstructor(string buildingID, string state, string exception)
        {
            Assert.Throws<ArgumentException>(() => new BuildingController(buildingID, state));
        }

        //L3R1
        //since we cannot write a test case to see if the depencies are injected for the constructor,
        //ive written a test case to return the state set by the constructor
        [TestCase("dependency", "out of hours")]

        public void TestForConstructorWithDependies_ByVerfyingStateIsSetToOutOfHours(string buildingID, string reutrnedState)
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            var state = buildingController.GetCurrentState();

            //Assert
            Assert.AreEqual(state, reutrnedState);
        }


        //L3R2
        //lights
        [TestCase("Lights,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,")]
        public void GetStatus_Returns_StringLights(string returnMessage)
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            var message = LightManager.GetStatus();

            //Assert
            Assert.AreEqual(message, returnMessage);
        }

        //doors
        [TestCase("Doors,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,")]
        public void GetStatus_Returns_StringDoors(string returnMessage)
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            var message = DoorManager.GetStatus();

            //Assert
            Assert.AreEqual(message, returnMessage);
        }



        //fire alarm
        [TestCase("FireAlarm,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,")]
        public void GetStatus_Returns_StringFirealarm(string returnMessage)
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            var a = FireAlarmManager.GetStatus();

            //Assert
            Assert.AreEqual(a, returnMessage);
        }

        //L3R3
        [TestCase("Lights,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,Doors,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,FireAlarm,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,")]
        public void GetStatusReport_Returns_Requiredstring(string returnMessage)
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            var message = buildingController.GetStatusReport();

            //Assert
            Assert.AreEqual(message, returnMessage);
        }

        //L3R5
        //normal flow -no failures
        [TestCase(true)]
        public void SetCurrentstate_ReturnsTrue_When_NoFailures(bool returnMessage)
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            bool returnedValue = buildingController.SetCurrentState("open");

            //Assert
            Assert.AreEqual(returnedValue, returnMessage);
        }

        //L3R4
        //alt flow - failure to open door

        [TestCase(false)]
        public void SetCurrentstate_ReturnsFalse_WhenFailure_ToOpenDoor(bool returnMessage)
        {
            //Arrange
            var buildingControllerV2 = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManagerV2, WebService, EmailService);

            //Act
            bool returnedValue = buildingControllerV2.SetCurrentState("open");

            //Assert
            Assert.AreEqual(returnedValue, returnMessage);
        }

        //below, the test for the state reverting back to out of hours was tested by changing the bool value in the interface
        [TestCase("out of hours")]
        public void SetCurrentstate_ReturnsFalse_WhenFailure_ToOpenDoor(string defaultState)
        {
            //Arrange

            var buildingControllerV2 = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManagerV2, WebService, EmailService);

            //Act
            buildingControllerV2.SetCurrentState("open");
            var currentState = buildingControllerV2.GetCurrentState();

            //Assert
            Assert.AreEqual(defaultState, currentState);
        }

        //L4R1
        [Test]
        public void LockAllDoors_IsCalled_WhenStateSetTo_Closed()
        {

            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            buildingController.SetCurrentState("closed");

            //Assert
            DoorManager.Received().LockAllDoors();
        }

        [Test]
        public void SetAllLights_IsCalled_WhenStateSetTo_Closed()
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            buildingController.SetCurrentState("closed");

            //Assert
            LightManager.Received().SetAllLights(false);
        }

        [Test]
        public void LockAllDoorsANDSetAllLights_Called_WhenStateSetTo_Closed()
        {

            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            buildingController.SetCurrentState("closed");

            //Assert
            DoorManager.Received().LockAllDoors();
            LightManager.Received().SetAllLights(false);
        }

        //L4R2
        [Test]
        public void SetAlarm_IsCalled_WhenStateSetTo_FireAlarm()
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            buildingController.SetCurrentState("fire alarm");

            //Assert
            FireAlarmManager.Received().SetAlarm(true);
        }

        [Test]
        public void OpenAllDoors_IsCalled_WhenStateSetTo_FireAlarm()
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            buildingController.SetCurrentState("fire alarm");

            //Assert
            DoorManager.Received().OpenAllDoors();
        }

        [Test]
        public void SetAllLights_IsCalled_WhenStateSetTo_FireAlarm()
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            buildingController.SetCurrentState("fire alarm");

            //Assert
            LightManager.Received().SetAllLights(true);
        }

        [Test]
        public void logFireAlarm_IsCalled_WhenStateSetTo_FireAlarm()
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            buildingController.SetCurrentState("fire alarm");

            //Assert
            WebService.Received().LogFireAlarm("fire alarm");
        }

        [Test]
        public void AllFunctions_AreCalled_WhenStateSetTo_FireAlarm()
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            buildingController.SetCurrentState("fire alarm");

            //Assert
            FireAlarmManager.Received().SetAlarm(true);
            DoorManager.Received().OpenAllDoors();
            LightManager.Received().SetAllLights(true);
            WebService.Received().LogFireAlarm("fire alarm");
        }

        //L4R3
        //Lights return a fault
        [Test]
        public void EngineerRequired_When_LightsReturnsFaults()
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManagerV2, FireAlarmManager, DoorManager, WebService, EmailService);

            //Act
            buildingController.GetStatusReport();

            //Assert
            WebService.Received().LogEngineerRequired("Lights");
        }

        //Fire alarm returns a fault
        [Test]
        public void EngineerRequired_When_FireAlarmReturnsFaults()
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManagerV2, DoorManager, WebService, EmailService);

            //Act
            buildingController.GetStatusReport();

            //Assert
            WebService.Received().LogEngineerRequired("FireAlarm");
        }

        //Doors returns a fault
        [Test]
        public void EngineerRequired_When_DoorsReturnsFaults()
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManager, DoorManagerV2, WebService, EmailService);

            //Act
            buildingController.GetStatusReport();

            //Assert
            WebService.Received().LogEngineerRequired("Doors");
        }

        //lights and doors returns a fault
        [Test]
        public void EngineerRequired_When_LightsANDDoorsReturnsFaults()
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManagerV2, FireAlarmManager, DoorManagerV2, WebService, EmailService);

            //Act
            buildingController.GetStatusReport();

            //Assert
            WebService.Received().LogEngineerRequired("Lights,Doors");
        }

        //lights and fire alarm returns a fault
        [Test]
        public void EngineerRequired_When_LightsANDFireAlarmReturnsFaults()
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManagerV2, FireAlarmManagerV2, DoorManager, WebService, EmailService);

            //Act
            buildingController.GetStatusReport();

            //Assert
            WebService.Received().LogEngineerRequired("Lights,FireAlarm");
        }

        // doors and fire alarm returns a fault
        [Test]
        public void EngineerRequired_When_DoorsANDReturnsFaults()
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManager, FireAlarmManagerV2, DoorManagerV2, WebService, EmailService);

            //Act
            buildingController.GetStatusReport();

            //Assert
            WebService.Received().LogEngineerRequired("Doors,FireAlarm");
        }

        //lights, doors & fire alarm return faults
        [Test]
        public void EngineerRequired_When_LightsANDDoorsANDFireAlarmReturnsFaults()
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManagerV2, FireAlarmManagerV2, DoorManagerV2, WebService, EmailService);

            //Act
            buildingController.GetStatusReport();

            //Assert
            WebService.Received().LogEngineerRequired("Lights,Doors,FireAlarm");
        }

        //L4R4
        [Test]
        public void EmailSet_If_LogFireAlarmThrowException()
        {
            //Arrange
            var buildingController = new BuildingController("testbuilding", LightManagerV2, FireAlarmManagerV2, DoorManagerV2, WebService, EmailService);
            WebService.When(f => f.LogFireAlarm("fire alarm")).Do(f => throw new InvalidOperationException());

            //Act
            buildingController.SetCurrentState("fire alarm");

            //Assert
            EmailService.Received().SendMail("smartbuilding@uclan.ac.uk", "failed to log alarm", "Operation is not valid due to the current state of the object.");
        }

    }
}