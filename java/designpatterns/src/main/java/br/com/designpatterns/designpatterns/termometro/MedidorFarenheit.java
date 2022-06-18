package br.com.designpatterns.designpatterns.termometro;

import java.util.Random;

public class MedidorFarenheit {
    
    public double getTemperaturaFarenheit() {
        return new Random().nextDouble(); // simulando o termometro
    }
}
