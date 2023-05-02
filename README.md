# SwapiTopTrump

Making a console app (so far) to use data from SWAPI.dev to play Top Trumps.
===02/05=== 

PersonModel and Linq updated to reflect data annotation for json read…
… intialization.

Succesfully called the API with new method and saved data to requestedpeople.json.

Have used requestedpeople.json to modify the data load in the Shuffle method in MethodsLogic and have 82 playable cards!!!

This has also caused some issues with unknown values (resolved to 0 if unknown) and affecting the cheat mode win% in an adverse way. There is also the aspect of now having numerous 0 values affecting the win logic with regards to 0 having a win% of 28% on Mass attriubute.

Game logic for cheat mode needs reviewing and updating regarding win(maybe at a draw % if == 0).

Also need to update the call method to a menu item so that requested people can be called (show a graphical cards loading etc).

Need to update all PersonModelLinq to just PersonModel as can now play without hardcoded values.(need a if Shuffle() returns empty list call api)


===12-14/04===

Made quite a few changes, added a PlayerModel and refactored code input and parameter values to reflect the new model. Corrected some bugs that were throwing OutOfRange exceptions. Hardcoded more card values and increased chooseable options with logic for 2 additional fields (4 total choices)

===14/03===

App is working as of 14/03 but is limited to only Height, Mass and 5 Hardcoded card values. There are some bugs to iron out with cheatmode not displaying correct win% some turns (with possibility of making it more accurate based on opponents hand cards etc as apposed to its current total cards)

