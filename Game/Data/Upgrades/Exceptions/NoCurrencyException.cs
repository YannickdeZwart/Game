public class NoCurrencyException : Exception {
    public NoCurrencyException(string currencyName): base("You dont have enough " + currencyName + " to buy this upgrade") {}
}