import random
import sys
sys.setrecursionlimit(4005)
#code to change recursion limit taken from;
#https://stackoverflow.com/questions/3323001/what-is-the-maximum-recursion-depth-in-python-and-how-to-increase-it

#code for reading from file to list: https://www.geeksforgeeks.org/how-to-read-text-file-into-list-in-python/
def read_list(fileName, outputName):
   fileOpenName =open(fileName, "r")
   fileRead=fileOpenName.read()
   list=fileRead.split("\n")
   finalList=random.choices(list, k=4000)
   print(outputName, " name  list  trimmed  to  ", len(finalList), " random  names")
   return finalList


firstName = read_list("FirstName.txt", 'First')
LastName = read_list("LastName.txt", 'Last')

#concatenating 2 lists: https://www.geeksforgeeks.org/python-ways-to-concatenate-two-lists/
def Combine_Lists():

   list = LastName
   i: int = 0
   for i in range(0, 4000):
      list[i] = (firstName[i] + ' ' + LastName[i])

   return list


sortedList = Combine_Lists()


def recursive_longest(importedList):
   #iteration is used to move through the list of names
   if len(importedList) == 1:
      return importedList[0]

   current = importedList[0]
   longest = recursive_longest(importedList[1:])

   if len(current) < len(longest):
      return longest
   else:
      return current


longestString = recursive_longest(sortedList)
print("Longest name in final list is: ", longestString)


def file_output(final, longestName):
   output = open("fullNames.txt", "w")
   output.write("Longest word is ")
   output.write(longestName)
   output.write('\n')
   i: int = 0
   for i in range(0, 4000):
      output.write(str(i+1))
      output.write("- ")
      output.write(final[i])
      output.write(" \n")

   output.close()


file_output(sortedList, longestString)