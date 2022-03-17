using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Direccion {
	Arriba,
	Abajo, 
	Izquierda, 
	Derecha
}

public class Pin : MonoBehaviour {
	[Header("Opciones")]
	public bool EsAutomatico;
	public bool HideIcono;
	public Estacion estacion;

	[Header("Pins")]
	public Pin PinArriba;
	public Pin PinAbajo;
	public Pin PinIzquierda;
	public Pin PinDerecha;
	public bool desbloqueado;

	private Dictionary<Direccion, Pin> pinDirecciones;

	private void Start(){

		pinDirecciones = new Dictionary<Direccion, Pin>{
			{Direccion.Arriba, PinArriba},
			{Direccion.Abajo, PinAbajo},
			{Direccion.Izquierda, PinIzquierda},
			{Direccion.Derecha, PinDerecha}
		};

		if (HideIcono){
			GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	public Pin GetPinEnDireccion(Direccion direccion){
		switch(direccion){
			case Direccion.Arriba:
				return PinArriba;
			case Direccion.Abajo:
				return PinAbajo;
			case Direccion.Izquierda:
				return PinIzquierda;
			case Direccion.Derecha:
				return PinDerecha;
			default:
				throw new ArgumentOutOfRangeException("Direccion", direccion, null);
		}	
	}

	public Pin GetPinSiguiente(Pin pin) {
		return pinDirecciones.FirstOrDefault(x => x.Value != null && x.Value != pin).Value;
	}

	private void OnDrawGizmos(){
		if (PinArriba != null) DrawLine(PinArriba);
		if (PinDerecha != null) DrawLine(PinDerecha);
		if (PinIzquierda != null) DrawLine(PinIzquierda);
		if (PinAbajo != null) DrawLine(PinAbajo);
	}

	protected void DrawLine(Pin pin){
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, pin.transform.position);
	}

}
