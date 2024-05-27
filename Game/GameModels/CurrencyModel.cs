using System;

public class CurrencyModel {
    public String coins;

    public CurrencyModel(Currency currency)
    {
        this.coins = Math.Floor(currency.coins).ToString();
    }
}