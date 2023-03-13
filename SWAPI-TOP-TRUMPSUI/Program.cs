using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.VisualBasic;
using SWAPI_TOP_TRUMPSUI;
using SWAPI_TOP_TRUMPSUI.Models;


// Trying to make a Top Trumps app using information from SWAPI.dev
// WORK IN PROGRESS

ConsoleUI.StartUpUI();








//testing some linq/data loading stuff

//List<PersonModelLinq> linqPeople = PeopleRepository.GetAll();

//var list = (from p in linqPeople select p).ToList();

//foreach (PersonModelLinq item in list)
//{ Console.WriteLine(item.Name); }

//Console.WriteLine($"This is postion 0 name : {list[0].Name}.");

//Console.WriteLine(list.Count);

//double test = MethodsLogic.CalculateWinHeight(linqPeople, linqPeople[1].Height);
//Console.WriteLine($"Your have {test}% of winning with Height of {linqPeople[1].Height} on {linqPeople[1].Name}.");


//double test2 = MethodsLogic.CalculateWin(linqPeople, linqPeople[1].Mass, "Mass");

//double test3 = MethodsLogic.CalculateWin(linqPeople, linqPeople[1].Height, "Height");



//CardValues(linqPeople, 1);
//CardWinAll(linqPeople, 1);


//CardValues(linqPeople, 4);
//CardWinAll(linqPeople, 4);

// given a card information want to detail chances of winning on all properties
static void CardValues(List<PersonModelLinq> itemList, int index)
{
    //print all values
    Console.WriteLine($"Name: {itemList[index].Name}");
    Console.WriteLine($"Height: {itemList[index].Name}");
    Console.WriteLine($"Mass: {itemList[index].Name}");
}
static void CardWinAll(List<PersonModelLinq> itemList, int index)
{
    // based on index position of card call calculatewin() to display value + win%

    double height = MethodsLogic.CalculateWin(itemList, itemList[index].Height, "Height");
    double mass = MethodsLogic.CalculateWin(itemList, itemList[index].Mass, "Mass");

    Console.WriteLine($"Name: { itemList[index].Name }");
    Console.WriteLine($"Height: { itemList[index].Name }\t Win%: { height }");
    Console.WriteLine($"Mass: { itemList[index].Name }\t Win%: { mass }");
}
