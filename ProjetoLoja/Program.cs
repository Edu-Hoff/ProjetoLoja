using System;
using Gerenciadores;
using InterfaceConsole;



GerenciadorLoja GerenciadoDeLoja = new GerenciadorLoja();
//GerenciadoDeLoja.InicializaEntidades();
InterfacePrincipal InterfaceDoConsole = new InterfacePrincipal(GerenciadoDeLoja);
InterfaceDoConsole.MenuInicial("Mercado do Ze");//Podem mudar se quiser

