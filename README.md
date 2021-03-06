# VotosSENADO

URL: www.votossenado.net

API: www.votossenado.net/api

O **VotosSENADO** é sistema de coleta, análise e monitoramento dos votos dos senadores em cada matéria que está em tramitação ou já tramitou durante o período da legislatura atual.

Todos os dados são obtidos do [Serviços de Dados Abertos Legislativos do Senado Federal](http://legis.senado.leg.br/dadosabertos/docs/index.html)

Os dados coletados são tratados e armazenados em um banco de dados local para que possam ser disponibilizados em uma estruturação adequada pela API interna, que é consumida pela aplicação principal. 

A listagem de senadores contempla aqueles que estão em exercício no dia. Se algum senador não aparecer na lista, é provável que tenha tirado licença e um dos respectivos suplentes tenha assumido, fazendo com que o próprio suplente apareça na lista, provisoriamente, até que o senador retorne da licença.

**O VotosSENADO possibilita:**
* Listar todos os senadores que estão em exercício no dia atual
* Listar todas as matérias que foram ou serão votadas na legislatura atual
* Acompanhar, através de gráficos, se um senador está predominantemente votando a favor ou contra determinado assunto (geral ou específico)
* Acompanhar, através de gráficos, se um senador está presente durante as votações, mas não está registrando voto
* Acompanhar, através de gráficos, se um senador não está presente nas votações

**Observações gerais:**
* Muitas matérias tiveram votação secreta e, portanto, os seus respectivos votos não foram considerados
* Muitas matérias não estavam vinculados a um assunto. Para esses casos, foi criado uma tag "- Sem Assunto", para que todos os votos não-secretos pudessem ser considerados nas análises gráficas  
  * Exemplo de Matéria sem vínculo com um Assunto (não possui a tag XML "Assunto"):
    http://legis.senado.leg.br/dadosabertos/materia/124633
  * Exemplo de Matéria vinculada a um Assunto (possui a tag XML "Assunto"):
    http://legis.senado.leg.br/dadosabertos/materia/123060
    
**TODO (Próximas versões):**
* Página do senador, com informações mais específicas (como contato telefônico, endereço do gabinete, local de nascimento)
* Gráficos de votações por partido
* Gráficos de votações por assunto (geral ou específico)
