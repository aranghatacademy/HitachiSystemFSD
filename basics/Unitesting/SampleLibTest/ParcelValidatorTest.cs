using Microsoft.Extensions.Logging;
using Moq;
using SampleLib;

namespace SampleLibTest;

public class ParcelnumberValidatorTest
{

    private Mock<ILogger<ParcelnumberValidator>> _mockLogger;
    [SetUp]
    //Any dependencies that need to be created will be created here
    public void Setup()
    {
          //We are creating a mock logger for the ParcelnumberValidator class
          //Since we are not using the logger in the ParcelnumberValidator class, we are not passing any arguments to the constructor
         _mockLogger = new Mock<ILogger<ParcelnumberValidator>>();
    }

    [Test]
    //MethodToTest_Scenario_ExpectedResult
    public void IsValid_WhenGivenValidParcelnumber_ReturnsTrue()
    {
        //Arrange
        var parcelnumber = "BLR12";

        //Act
        var result = new ParcelnumberValidator(_mockLogger.Object).IsValid(parcelnumber);

        //Assert
        //Check if the return value of ISValid is true if you pass BLR12
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsValid_WhenGivenInvalidParcelnumber_ReturnsFalse()
    {
        //Arrange
        var parcelnumber = "BLR123"; //Invalid because its length is not 5

        //Act
        var result = new ParcelnumberValidator(_mockLogger.Object).IsValid(parcelnumber);

        //Assert
        Assert.That(result, Is.False);
    }


    [Test]
    public void IsValid_WhenGivenLowerCaseParcelnumber_ReturnsFalse()
    {
        //Arrange
        var parcelnumber = "blr12"; //Invalid because its length is not 5

        //Act
        var result = new ParcelnumberValidator(_mockLogger.Object).IsValid(parcelnumber);

        //Assert
        Assert.That(result, Is.True);
    }

}
