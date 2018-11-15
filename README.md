# JurosCompostos

Projeto de Calculadora de Juros compostos

Esse projeto foi construído utilizando as seguintes tecnologias:

- Asp.Net Core, com as features abaixo:    
    + Swagger: A api foi desenhada no swagger, o projeto foi gerado pelo swagger editor.
    + Dependence Injection: Utilizado para manter fraco acoplamento entre objetos.
    + Layers: A API é uma camada publica que invoca a camada de serviços, nesse caso implementado numa biblioteca (.dll) o que 
      possibilitaria, por exemplo, a construção de múltiplos serviços (WCF, WebServices, etc.) utilizando a mesma base de códigos.
      
- Testes Unitários:
  + Cobrindo os serviços de Arredondamento e Calculo de Juros.
  
Obs: O testes comparam os valores em string. Para que isso não seja necessário, os tipos de dados precisariam ser alterados para decimal.
Isso é uma decisão de projeto que impacta na precisão da informação, visto que decimal < double, caso o tipo seja suficientemente grande
para a aplicação, o tipo de dado decimal seria mais adequado, visto que não é ponto fluante binário e não gera problemas ao comparar 
valores que não podem ser completamente representados pelos tipos binarios (float, double).
