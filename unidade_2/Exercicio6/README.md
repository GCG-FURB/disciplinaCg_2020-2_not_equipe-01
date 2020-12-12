# 6. Spline

Já esta aplicação o seu objetivo é poder desenhar uma spline (curva polinomial) que permita alterar a posição (x,y) dos pontos de controle dinamicamente utilizando o teclado. As dimensões da janela com valores (xMin: -400, xMax: 400, yMin: -400, yMax: 400) e os pontos são valores de 100 negativo e positivo de forma que o resultado final seja o mais parecido com o vídeo a baixo.
No caso a interação deve ser:

- para mudar entre o ponto de controle selecionado (em cor vermelha) usar as teclas “1, 2, 3 e 4”;

- para mover o ponto selecionado (um dos pontos de controle) usar as teclas C (cima), B (baixo), E (esquerda) e D (direita);
- as teclas do sinal de mais (+) e menos (-) podem aumentar e diminui a quantidade de pontos calculados na spline;
- ao pressionar a tecla R os pontos de controle devem voltar aos valores iniciais;
- a spline deve ser desenha usando linhas de cor amarela;
- o poliedro de controle deve ser desenhado usando uma linha de cor ciano.

**ATENÇÃO**: não é permitido usar o comando spline do OpenGL, sendo só permitido usar UMA das formas de splines “demonstradas em aula”. Ao mover um dos pontos de controle, o poliedro e a spline deve se ajustar aos novos valores deste ponto.
Veja o exemplo no vídeo a baixo.

Use a classe SegReta para desenhar o poliedro de controle e crie uma nova classe para representar o objeto gráfico Spline em Spline.cs.