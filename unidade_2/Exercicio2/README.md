# 2. Funções de Pan e Zoom
Crie uma nova aplicação (ver vídeo abaixo) usando como base o exercício anterior (neste caso o fundo de cor branca e desenho preto) para implementar as funções de Pan e Zoom. Para isso, implemente uma função de callback de teclado que leia as teclas e os parâmetros necessários para a função Ortho. Tais parâmetros deverão ser armazenados em uma classe Camera. 

## Observações:

- tecla Pan (deslocar para esquerda): E;
- tecla Pan (deslocar para direita): D;
- tecla Pan (deslocar para cima): C;
- tecla Pan (deslocar para baixo): B;
- tecla Zoom in (aproximar): I;
- tecla Zoom out (afastar): O.

Não esqueça de “tratar” os limites de zoom mínimo e máximo senão poderá ocorrer erros de execução, ou até a inversão horizontal/vertical do desenho na tela. Geralmente estes “problemas” ocorrem devido ao tipo de variável declarada para armazenar o “passo” do zoom atual. Lembre de usar a classe Circulo criada no exercício anterior.