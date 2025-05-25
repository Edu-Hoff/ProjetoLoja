using System;
using Gerenciadores;
using InterfaceConsole;



GerenciadorLoja GerenciadoDeLoja = new GerenciadorLoja();
InterfacePrincipal InterfaceDoConsole = new InterfacePrincipal(GerenciadoDeLoja);
InterfaceDoConsole.MenuInicial("Mercado do Ze");//Podem mudar se quiser

