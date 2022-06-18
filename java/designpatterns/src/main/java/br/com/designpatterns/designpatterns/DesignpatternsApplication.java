package br.com.designpatterns.designpatterns;

import br.com.designpatterns.designpatterns.termometro.AdaptadorFarenheitParaCelsiusObjectAdapter;
import br.com.designpatterns.designpatterns.termometro.MedidorFarenheit;

public class DesignpatternsApplication {

	public static void main(String[] args) {
		//Cria e instancia o o termômetro no exterior
		MedidorFarenheit medidorFarenheit = new MedidorFarenheit();
		//Classe adaptadora para integração de novos temômetros
		AdaptadorFarenheitParaCelsiusObjectAdapter adaptadorFarenheitParaCelsiusObjectAdapter = new AdaptadorFarenheitParaCelsiusObjectAdapter(medidorFarenheit);
		System.out.println(String.format("A temperatura comvertida para Ceulsius = %s", adaptadorFarenheitParaCelsiusObjectAdapter.medirTemperatura()));
	}

}
