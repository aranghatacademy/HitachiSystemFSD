using SampleLib;

namespace SampleLibTest;

public class ParcelnumberValidatorTest
{
    [SetUp]
    //Any dependencies that need to be created will be created here
    public void Setup()
    {
    }

    [Test]
    //MethodToTest_Scenario_ExpectedResult
    public void IsValid_WhenGivenValidParcelnumber_ReturnsTrue()
    {
        //Arrange
        var parcelnumber = "BLR12";

        //Act
        var result = ParcelnumberValidator.IsValid(parcelnumber);

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
        var result = ParcelnumberValidator.IsValid(parcelnumber);

        //Assert
        Assert.That(result, Is.False);
    }


    [Test]
    public void IsValid_WhenGivenLowerCaseParcelnumber_ReturnsFalse()
    {
        //Arrange
        var parcelnumber = "blr12"; //Invalid because its length is not 5

        //Act
        var result = ParcelnumberValidator.IsValid(parcelnumber);

        //Assert
        Assert.That(result, Is.True);
    }

}
