using System;
using Gerenciadores;
using InterfaceConsole;



GerenciadorLoja GerenciadoDeLoja = new GerenciadorLoja();
//Se quiser testar sem inicializar
GerenciadoDeLoja.InicializaEntidades();
InterfacePrincipal InterfaceDoConsole = new InterfacePrincipal(GerenciadoDeLoja);
InterfaceDoConsole.MenuInicial("Mercado do Ze");//Podem mudar se quiser

