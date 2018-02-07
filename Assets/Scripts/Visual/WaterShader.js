#pragma strict

var underwaterColor : Color;
var densityFog : float;

/*

Esse código deve ser aplicado na camera e faz mudar o fog para os parametros de cor e densidade acima

Lembrar de ativar o fog nas configuracoes EDIT -> RENDERSETTINGS, mas essas configs de cor e densidade 
serao sobrescritas com esse codigo

*/

function Start () //Update para testes dinamicos	
{	
	RenderSettings.fogColor = underwaterColor;
	RenderSettings.fogDensity = densityFog;
}