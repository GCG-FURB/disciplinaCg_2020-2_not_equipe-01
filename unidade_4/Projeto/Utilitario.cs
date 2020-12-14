/**
  Autor: Dalton Solano dos Reis
**/

using System;

namespace gcgcg
{
  public abstract class Utilitario
  {
    public static char charProximo(char atual) {
      return Convert.ToChar(atual + 1);
    }
  }
}