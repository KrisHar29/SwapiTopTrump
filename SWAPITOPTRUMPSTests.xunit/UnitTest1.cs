namespace SWAPITOPTRUMPSTests.xunit;
using SWAPI_TOP_TRUMPSUI;
public class UnitTest1
{
    //[Fact]
    //public void WrongMainMenuInputThrowException()
    //{
    //    var sut = new ConsoleUI.AskUserOptionMainMenu();

    //    Assert.Throws<Exception>(
    //        () => sut.AskUserOptionMainMenu(input = 5)); ;  ;
    //}

    [Fact]
    public void AskUserOptionMainMenu_ThrowsExceptionWhenInputIsZero()
    {
        
            // Arrange
            var input = "0";

            // Act
            var exception = Record.Exception(() => AskUserOptionMainMenu(input));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
            Assert.Equal("========================\r\nInvalid input try again!\r\n========================\r\n", Console.Out.ToString());
        
    }

    private int AskUserOptionMainMenu(string input)
    {
        // Replace the Console.ReadLine() call with a string parameter for testing
        try
        {
            int userInput = int.Parse(input);
            if (userInput <= 0 || userInput > 4)
            {
                throw new Exception();
            }
            return userInput;
        }
        catch (Exception)
        {
            //Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("Invalid input try again!");
            Console.WriteLine("========================");
            return 0;
        }
    }
}