namespace Tests
{
    public class BoxTests
    {
        [Fact]
        public void Box_CalculateExpirationDate_ProductionDate()
        {
            var box = new Box { DateOfManufacture = new DateOnly(2023, 1, 1) };

            var expiryDate = box.CalculateExpirationDate();

            Assert.Equal(new DateOnly(2023, 4, 11), expiryDate);
        }

        [Fact]
        public void Box_CalculateExpirationDate_ExpirationDate()
        {
            var box = new Box { ExpirationDate = new DateOnly(2023, 6, 1) };

            var expiryDate = box.CalculateExpirationDate();

            Assert.Equal(new DateOnly(2023, 6, 1), expiryDate);
        }

        [Fact]
        public void Box_Volume()
        {
            var box = new Box { Width = 10, Height = 10, Depth = 10 };

            var volume = box.CalculateVolume();

            Assert.Equal(1000, volume);
        }      
    }
}