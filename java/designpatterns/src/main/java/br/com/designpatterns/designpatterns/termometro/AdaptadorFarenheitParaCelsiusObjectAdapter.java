package br.com.designpatterns.designpatterns.termometro;

public class AdaptadorFarenheitParaCelsiusObjectAdapter implements MedidorCelsius {

    private MedidorFarenheit medidorFarenheit;

    public AdaptadorFarenheitParaCelsiusObjectAdapter(MedidorFarenheit medidorFarenheit){
        this.medidorFarenheit = medidorFarenheit;
    }

    //Implementa o método da interface, para converter de Farenheit Para Celsius
    public double medirTemperatura() {
        //C° = (°F − 32) ÷ 1,8
        return (medidorFarenheit.getTemperaturaFarenheit() - 32) / 1.8;
    }
}
