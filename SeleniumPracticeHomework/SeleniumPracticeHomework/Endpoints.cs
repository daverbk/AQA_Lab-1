namespace SeleniumPracticeHomework
{
    public static class Endpoints
    {
        private const string LaminateCalculatorServiceUrl = "https://calc.by";
        private const string LaminateCalculatorPrefix = "/building-calculators";
        
        public static readonly string LaminateCalculatorFullUrl =
            $"{LaminateCalculatorServiceUrl}{LaminateCalculatorPrefix}/laminate.html";
        
        private const string ElectricFloorServiceUrl = "https://kermi-fko.ru";
        private const string ElectricFloorPrefix = "/raschety";

        public static readonly string ElectricFloorHeatingCalculatorFullUrl =
            $"{ElectricFloorServiceUrl}{ElectricFloorPrefix}/Calc-Rehau-Solelec.aspx";
        
        private const string LaminateFlooringServiceUrl = "https://masterskayapola.ru";
        private const string LaminateFlooringPrefix = "/kalkulyator";
        
        public static readonly string LaminateFlooringCalculatorFullUrl =
            $"{LaminateFlooringServiceUrl}{LaminateFlooringPrefix}/laminata.html";
    }
}
