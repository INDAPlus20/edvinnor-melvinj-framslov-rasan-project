# Specifications

## Overview

* We will be making a boardgame based on surviving datateknink at KTH including the stress and necessary resource management.
* Documentation: C# Docs - https://docs.microsoft.com/en-us/dotnet/csharp/
* Style Guide: C# Coding Conventions - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions

## Roles

* Edvin (edvinnor) - frontend coding
* Melvin (melvinj) - backend coding, game component structure
* Filip (framslov) - game design, presentation, QA

## Tools

* Engine: Unity
* Code: Visual Studio
* Models: Blender
* Textures: GIMP

## Gameplay (WIP)

The goal of the game is to complete assigments and earn hp. First to reach 300 hp and graduate wins!
Players take turns drawing cards and completing actions four times per year, for five (or more) years.


* Resources
    * Stamina (mainly spent to complete assigments but may have other uses?)
    * Money (spent on events to earn stamina or on couse material to facilitate studying but may have other uses?)
    * Friends (Unique uses, may help with assignment or share residence to reduce rent for instance)
    * Items?

* Cards
    * Course (a course worth between [LOWER AMOUNT] and 18 hp to be completed immediately or at a later time)
    * 'Sektion' (an event happening at the 'sektion' where participation is optional but beneficial in most cases)
    * Event (a campus-wide event that has a significant impact on the game as a whole)

* Turn structure
    * Draw a course card and show it to all players
    * Decide if you choose to take the course this period (turn) or alternatively take a break to recover stamina or earn extra money
    * Draw a 'sektions' card
    * Decide how to spend your resources. Will you attend the event and/or make a purchase?
    * Spend stamina to complete the course or set it aside for later

* Notes
    * At period four, instead of drawing a course card you are assigned a course worth [60 - hp of previous three courses] hp with a corresponding stamina cost
    * When assigned a course at round start you may set is aside to attend an uncompleted course or try to attend both simultaneously
    * All courses total exactly 300 hp and no new courses may be attended after year 5 meaning no course can be left uncompleted
    * At the end of the year draw an event card

* Trivia
    * Much like real life, there are 'omtentor' but no 'omfester'
    * Unlike real life however, you can graduate without ever having to face a ProSam assignment

## Challenges

* Dividing work equally
* Setting retrictions
* Translating Java knowledge to C#
* Dynamic game mechanics
* Textures in GIMP

## Feasibility
Unity does most of the work for us so we'll at least get something to run. The real question is if we can live up to our own hype...