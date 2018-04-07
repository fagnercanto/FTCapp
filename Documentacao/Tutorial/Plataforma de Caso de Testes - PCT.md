

# **⟳** FTCapp ▶

> ​               friendly test case app



##INDICE

[TOC]



> A parte técnica não é o objetivo desse documento

## Pré requisitos
- Apresentar interface de usúario Amigável e ergonômica.
- Criar casos e suítes de testes automatizados e dinâmicos.
  - Casos que incluam uma ou mais funcionalidades
  - Troca de telas
  - Consultas no proprio sistema
- Armazenar casos de testes.
- Rodar casos de testes.
- Armazenar suítes de testes.
- Rodar suítes de testes.
- Operável por usuário que tenha conhecimento de negocio e do sistema.
  - Foi planejado para que partes das equipes de qualidade e testes pudessem operar o app sem o conhecimento de linguagem de programação




## Para que serve?
- Cobertura de regras de negocios.
- Evidencia de Erro.
  - É possivel passar um caso de testes para um colega te trabalho
- Auxilia em manter a integridade do sistema após alterações de funcionalidades.
  - Como os casos de testes ficam armazenados, é possível usar um caso de testes anterior a uma alteração para garantir que não houve impacto.




## Ações Automatizadas

- Acessar as telas do sistema.
- Se logar 
- Navegar
- Preencher campos
- Interagir com o DOM
- Recolher informações
- Acessar banco de dados do sistema afim de trazer informações de negocio uteis para o teste.
  - Enquanto o caso de testes esta rodando é possível recolher informações do bando de dados configuraveis pelo usuário e que interagem com os elementos da tela atual
    - Por exeplo se estamos consultando uma Unidade Gestora, é possível recolher o CDUNIDADEGESTORA (ou qualquer outro elemento do contexto) e inserir em um SCRIP SQL dinâmicamente.

## Ações do usuário Não tecnico

- Inserir login e senha
- Inserir dados de conexão com o banco de dados
- Inserir Tranzações/Conceitos ao qual deseja criar o caso de testes
- organizar os elementos na ordem que deseja que o teste seja executado

## Ações do usuário tecnico

- Inserir consultas Scripts SQL que podem interagir com o caso de testes  e podem usar elementos que estão presentes no contexto

--------------------------------



## Exemplo de Uso

> Abaixo segue um exemplo de teste simples para apresentar as funcionalidades do FTCapp



###Montar cenário de teste###

#### Definir Módulo, Conceito, Funcionalidade, Elementos e Eventos

- **Módulo** 
  - CTR
- **Conceito**
  - Edital Licitação Situação
- **Funcionalidade** 
  - Pesquisar
- **Elementos**
  - txtCdUnidadeGestora
  - txtCdGestao
  - txtNuEditalLicitacao
  - txtNuAnoEditalLicitacao
  - btnPesquisar


- **Valores**
  - txtCdUnidadeGestora = 270002
  - txtCdGestao = 1
  - txtNuEditalLicitacao = 1
  - txtNuAnoEditalLicitacao = 2018
- **Eventos**
  - btnPesquisar = Click


#### Definir sequencia


```mermaid
graph TB

M[USER]
B[Login]
C[Senha]
D[Ambiente]
E[Entrar]
G[CdUnidadeGestora]
H[CdGestao]
I[NuEditalLicitacao]
J[NuAnoEditalLicitacao]
L[Pesquisar]
N[Modulo]
O[Conceito]

subgraph Menu
N
O
end

subgraph Tela Login
B 
C 
D
E 
end

subgraph Edital LicitacaoSituacao
G 
H 
I 
J 
L 
end

M-->|insere|B
B-->|insere|C
C-->|insere|D
D-->|Clica|E

E-->|escolhe|N
N-->|Clica|O

O-->|insere|G
G-->|insere|H
H-->|insere|I
I-->|insere|J 
J-->|Clica|L
```



Esse é um exemplo de caso de uso simples agora imagine um cenário onde é necessário mais conplexo envolvendo varios formulários e conceitos. Cada vez que se deseja testar ou mesmo montar um cenário para um teste acaba gerando esforço repetitivo e muitas vezes o fluxo de interação não esta bem claro pro profissional que precisa chegar a um determinado estado do sistema para poder desenvolver uma evolutiva, corrigir um erro ou mesmo testar uma funcionalidade. Por isso vamos ver como fazer isso de forma automatizada cadastrando apenas uma vez todo o caso de testes.

### Cadastrar Caso de Teste no FTCapp

#### Inserir Cenário

A primeira coisa a fazer é inserir os dados do conceito para que o FTCapp recolha os elementos do mesmo. No Painel de Consulta basta preencher os campos

##### Cliente

- Salvador
- SC
- RN

#####Ambiente

- DSV
- HOM
- PRD

#####Conceito

- Alterar Edital Licitacao

#####Login

- Login do usuario no SIGEF

#####Senha

- Senha do usuario no SIGEF

No Painél ![52260805335](file:///C:\Users\Administrador\Documents\proposta\resourses\DCC.png) 

1. Insira os dados.

.![](file:///C:\Users\Administrador\Documents\proposta\resourses\DADOSCONCEITO.png)

2. Clique em Buscar Elementos ![52260820530](file:///C:\Users\Administrador\Documents\proposta\resourses\DCBTNB.png)
3. O FTCapp vai se logar, acessar a tela e recolher todos elementos relevantes presentes.
   - CTRAlterarEditalLicitacaoSituacao  (*Tela*)
   - CDUNIDADEGESTORA
   - CDGESTAO
   - EDITALLICITACAO
   - ANOEDITALLICITACAO
   - SITUACAOATUAL
   - DTSITUACAOATUAL
   - DTPUBLICACAODO
   - DTREPUBLICACAOPUBLICACAODO
   - OBSERVACAO
   - NOVASITUACAO
   - DTNOVASITUACAO
   - NUMERODO
   - NUMERODOREPUBLICADO
   - MSG (*Mensagem ERRO*)
4. No Backend o FTCapp guarda todas essas informações 
   - Elemento txtNuAnoEditalLicitacao

```html
<input 
	   name="txtNuAnoEditalLicitacao"
	   type="text" 
	   maxlength="4" 
	   id="txtNuAnoEditalLicitacao"
	   class="SIGEFTextbox" 
	   onmouseout="window.status=' '"
	   onKeyUp="AutoTabular(this,4,event);"
	   onpaste="javascript: return false;" 
	   oncontextmenu="javascript: return false;" onBlur="javascript: return FormatarValorNumerico(this, event, '9999');" onFocus="javascript:RemoverZerosEsquerda(this, event, '9999');" 
	   ondragenter="javascript: return false;"
	   onKeyPress="javascript: return ValidarDigito(this, event, '9999');" onmouseover="window.status='Informe o Ano do Edital Licitação';return true" style="width:45px;text-align:right;"
	   />
```

- Informações do conceito 

.![52260964728](file:///C:\Users\Administrador\Documents\proposta\resourses\SEA.png)

```javascript
{
  "Conceito": "CTRAlterarEditalLicitacaoSituacao",
  "Elementos": {
    "CDUNIDADEGESTORA": {
      "ID": "txtCdUnidadeGestora",
      "TIPO": "text"
    },
    "CDGESTAO": {
      "ID": "txtCdGestão",
      "TIPO": "Text"
    },
    "DTSITUACAOATUAL": {
      "ID": "txtDtSituacaoAtual",
      "TIPO": "date"
    },
    "DTPUBLICACAODO": {
      "ID": "txtdtPublicacaoDO",
      "TIPO": "date"
    },
    "PESQUISAR": {
      "ID": "btnPesquisar",
      "TIPO": "Buttom"
    },
    "NOVASITUACAO": {
      "ID": "CdNovaSitucao",
      "TIPO": "select"
    }
  }
}
```

4. Traz Todos os Elementos para o Fluxo de Teste

   ​

   ![52261012390](C:\Users\ADMINI~1\AppData\Local\Temp\1522610123907.png)

####Montar Cenário

O Paniel Fluxo de teste é composto por dois subPaineis **ELEMENTOS** e **CASO DE TESTE**

Todos os elementos que foram recolhidos da tela ficam dispostos a Esquera no sub Painel ELEMENTOS

Para montar o fluxo de caso de teste visto visto acima.

#####Escolher elementos

1. Clique sobre o elemento ![52261048812](C:\Users\ADMINI~1\AppData\Local\Temp\1522610488124.png)
2. Arraste ate o painel Direito CASO TESTES ![52261056632](C:\Users\ADMINI~1\AppData\Local\Temp\1522610566323.png)

##### Inserir Valores nos elementos



Arraste os elementos na sequencia que deseja que o teste seja realizado



1.5 Carregar Grid de Elementos

Poderiamos já inserir os valores que queremos preencher e já rodar o teste, porém não seria tão eficaz. Por que eu teria apenas um valor para cada elemento.  Para rodar o mesmo caso de teste com varios valores para cada elemento basta 

#####clicar em **![52227005459](C:\Users\fcanto\AppData\Local\Temp\1522270054594.png).**

Isso nos Leva para o painel **GRID ELEMENTOS**

![52226378450](C:\Users\fcanto\AppData\Local\Temp\1522263784500.png)

####1.6 Rodar o Caso de Teste

A **GRID ELEMENTOS** se monta automaticamento com os elementos que estão no Painel **CASO TESTE**

Você pode preencher os valores que deseja e 

#####Clicar em **![52227009778](C:\Users\fcanto\AppData\Local\Temp\1522270097781.png)**.

![52226375622](C:\Users\fcanto\AppData\Local\Temp\1522263756228.png)

O FTC 

1. ######Faz o login:

![GRID ELEMENTOS](C:\resourse\login.PNG)

2. ######Acessa a tela:


![GRID ELEMENTOS](C:\resourse\transacaoVazia.PNG)

3. ######Preenche os campos com os valores da GRID ELEMENTOS

![GRID ELEMENTOS](C:\resourse\transacaoPreenchidaPesquisa.PNG)

4. ######Clica em Pesquisar:

![GRID ELEMENTOS](C:\resourse\transacaoPreenchida.PNG)

5. Fecha o broswer ou mantem aberto dependendo da configuracão que o usuário optou ![52232858835](C:\Users\fcanto\AppData\Local\Temp\1522328588356.png)

####1.7 Inserir mais valores para o mesmo caso de testes

Cada Linha da **GRID ELEMENTOS** possui um botão ![52232958694](C:\Users\fcanto\AppData\Local\Temp\1522329586941.png) que serve para adicionar uma nova linha logo abaixo.

![52232948370](C:\Users\fcanto\AppData\Local\Temp\1522329483702.png)

Observe que a nova linha é adicionada com os mesmos valores da linha anterior. Agora basta alterar os valores que quiser

![52232972374](C:\Users\fcanto\AppData\Local\Temp\1522329723746.png)

E clicar no botão ![52232975050](C:\Users\fcanto\AppData\Local\Temp\1522329750507.png)

Agora em vez de rodar uma vez vai rodar duas e se deixar a opção ![52232987279](C:\Users\fcanto\AppData\Local\Temp\1522329872798.png) desmarcada o broswer permanece aberto em cada vez. Assim que fechar roda a próxima linha.



####Recapitulando:

Até aqui vimos a possibilidade de guardar casos de testes e montar cenários. 

- #####Prenchimento dos campos "transação", "usuário" e "senha" no painel **CONSULTA CASO DE TESTE**

![52226253660](C:\Users\fcanto\AppData\Local\Temp\1522262536601.png)

- #####O sistema traz todos os elementos da tela ELEMENTOS INTERACAO


![52226279703](C:\Users\fcanto\AppData\Local\Temp\1522262797034.png)

- #####O usuário adiciona os elementos que vai usar **CASO USO**

![52226245192](C:\Users\fcanto\AppData\Local\Temp\1522262451921.png)

- #####A Grid se monta dinamicamente de acordo com os elementos escolhidos **GRID ELEMENTOS**

![52226310341](C:\Users\fcanto\AppData\Local\Temp\1522263103417.png)

- #####O Usuário Preenche com os dados que deseja e roda o teste.

![52226303948](C:\Users\fcanto\AppData\Local\Temp\1522263039480.png)

O FTC executa o que foi programado na tela do conceito

![52227045966](C:\Users\fcanto\AppData\Local\Temp\1522270459668.png) ![52227047898](C:\Users\fcanto\AppData\Local\Temp\1522270478988.png)

#####Diagrama 



![52233576929](C:\Users\fcanto\AppData\Local\Temp\1522335769296.png)





```mermaid

```

###Passo a Passo Parte 2 - Validar Elementos

Continuando o passo a passo agora vamos criar as validações.

Exemplo:

Quero que teste se o campo ![52227398021](C:\Users\fcanto\AppData\Local\Temp\1522273980213.png) tem um valor igual a 2.

Como já sabemos que ele tem esse teste deve passar

Quando consultamos uma transação no inicio do passo a passo, além de carregar o Painel **ELEMENTOS INTERACAO** o FTC também carrega o Painél **ELEMENTOS VALIDACAO**

![52227542778](C:\Users\fcanto\AppData\Local\Temp\1522275536714.png)

Para gerar uma validação temos que incluir o elemento validação referente.

![52227398021](C:\Users\fcanto\AppData\Local\Temp\1522273980213.png)

![52227568703](C:\Users\fcanto\AppData\Local\Temp\1522275687037.png)

Clicar no botão ![52227570694](C:\Users\fcanto\AppData\Local\Temp\1522275706941.png)

Ele vai para o Painél **CASO TESTE**

![52227700355](C:\Users\fcanto\AppData\Local\Temp\1522277003558.png)

O Elemento Validação  quando esta no Painel **CASO TESTE** tem um desenho diferente. Ele posue dois combobox.  ![52233649011](C:\Users\fcanto\AppData\Local\Temp\1522336490118.png)

O primeiro define a validação 

Com as opções

.![52233669005](C:\Users\fcanto\AppData\Local\Temp\1522337379113.png)

O segundo combobox afirma ou nega o primeiro. Com as opções

.![52233747943](C:\Users\fcanto\AppData\Local\Temp\1522337479431.png)

####Validação de afirmação

Exemplos: 

Quero verificar se o ![52233752239](C:\Users\fcanto\AppData\Local\Temp\1522337522392.png) é igual a 2

Basta selecionar a opção ![52234615078](C:\Users\fcanto\AppData\Local\Temp\1522346150784.png) no primeiro combobox e ![52234617480](C:\Users\fcanto\AppData\Local\Temp\1522346174809.png) no segundo.

Vai ficar assim

.![52233649011](C:\Users\fcanto\AppData\Local\Temp\1522336490118.png)

Na verdade a gente já sabe que é ![52227398021](C:\Users\fcanto\AppData\Local\Temp\1522273980213.png)

Basta clicar em ![52233784620](C:\Users\fcanto\AppData\Local\Temp\1522337846209.png) A Grid vai ser montada dinâmicamente 

![52233794301](C:\Users\fcanto\AppData\Local\Temp\1522338819962.png)

Reparem que na GRID foi incluida a coluna NUMERODO:SIM IGUAL

.![52233886821](C:\Users\fcanto\AppData\Local\Temp\1522338868210.png)

####Inserir Valores de Validação

Basta incluir os valores![52234157128](C:\Users\fcanto\AppData\Local\Temp\1522341571287.png) 

e rodar ![52234147283](C:\Users\fcanto\AppData\Local\Temp\1522341472831.png) o Caso de teste.

O resultado pode ser observado no Painel **CASO TESTE**

.![52234233364](C:\Users\fcanto\AppData\Local\Temp\1522342333640.png)

####Validar um elemento mais de uma vez

Um elemento de validação possui o botão duplicar ![52234263103](C:\Users\fcanto\AppData\Local\Temp\1522342631034.png)

Se quisermos fazer mais de uma validação com o mesmo elemento basta clicar em ![52234267078](C:\Users\fcanto\AppData\Local\Temp\1522342670782.png)

Esse é o resultado

![52234287456](C:\Users\fcanto\AppData\Local\Temp\1522342874560.png)

Reparem que agora temos dois elementos para o mesmo campo NUMERODO[1] e NUMERODO[2]

![52234295066](C:\Users\fcanto\AppData\Local\Temp\1522342950664.png)![52234296582](C:\Users\fcanto\AppData\Local\Temp\1522342965825.png)

Essa vai ser a referencia de cada um deles na **GRID ELEMENTOS**

Vamos testar agora se o ![52233752239](C:\Users\fcanto\AppData\Local\Temp\1522337522392.png) é diferente de 2 e se ele é Somente Leitura

Para isso no elemento validação NUMERODO[1] vamos selecionar na primeira compobox a opção ![52234328263](C:\Users\fcanto\AppData\Local\Temp\1522343282633.png) e o segundo combobox a opção ![52234332042](C:\Users\fcanto\AppData\Local\Temp\1522343320422.png)

####Validação de negação

Quando selecionados a opção ![52234332042](C:\Users\fcanto\AppData\Local\Temp\1522343320422.png) do primeiro combobox significa que ele esta negando a primeira opção. 

Ou seja no caso da combinação dos combobox ficar IGUAL e NAO ![52234354408](C:\Users\fcanto\AppData\Local\Temp\1522343544080.png) isso significa que queremos saber se o valor inserido na GRID ELEMENTOS para ele é diferente do valor que estara no conceito ![52227398021](C:\Users\fcanto\AppData\Local\Temp\1522273980213.png), que nesse caso é igual a 2.  



O Elemento validação NUMERODO[1] vai ficar assim

.![52234349263](C:\Users\fcanto\AppData\Local\Temp\1522343492639.png)

Vamos configurar o elemento validação NUMERODO[2] para que esteja somente leitura.  O primeiro combobox ![52234380117](C:\Users\fcanto\AppData\Local\Temp\1522343801177.png) e o segundo ![52234385903](C:\Users\fcanto\AppData\Local\Temp\1522343859030.png).

Vai ficar assim ![52234376458](C:\Users\fcanto\AppData\Local\Temp\1522343764585.png).



O Painel CASO TESTE vai ficar assim:

.![52234397602](C:\Users\fcanto\AppData\Local\Temp\1522343976024.png)

Clicando em ![52234400463](C:\Users\fcanto\AppData\Local\Temp\1522344004631.png)

.![52234419025](C:\Users\fcanto\AppData\Local\Temp\1522345161227.png)

Agora temos duas referencias ao NUMERODO na grid,  Como Somente leitura não precisa inserir valor não tem a opão de editar. 

Basta preencher os valores 

![52234513382](C:\Users\fcanto\AppData\Local\Temp\1522345133827.png)

e ![52234424243](C:\Users\fcanto\AppData\Local\Temp\1522344242435.png).

O resultado no Painél CASO TESTE

![52234560784](C:\Users\fcanto\AppData\Local\Temp\1522345607840.png)

####Retorno do Caso de Teste

#####Retorno negativo

Caso a Validação não seja um sucesso o elemento validação que "não passou" fica em Vermelho no Painel **CASO TESTE** ![52234574458](C:\Users\fcanto\AppData\Local\Temp\1522345744583.png)

#####Retorno positivo

Como vimos acima quando a validação tem um retorno posivo o elemento validação fica com a cor verde.

![52234588272](C:\Users\fcanto\AppData\Local\Temp\1522345882721.png).



Agora vamos fazer uma serie de validações

####Validações Variáveis

Vamos fazer as seguintes validações

![52234648140](C:\Users\fcanto\AppData\Local\Temp\1522346481404.png) é maior de 3 ?

![52234648454](C:\Users\fcanto\AppData\Local\Temp\1522346484540.png) esta contido nessa lista  3,4,1,2,8 ?

![52234642707](C:\Users\fcanto\AppData\Local\Temp\1522346427075.png) contem esses caracteres "Edição"?

.![52234643949](C:\Users\fcanto\AppData\Local\Temp\1522346439490.png) esta contido nessa lista "Em Edição, Publicado"

.![52234644084](C:\Users\fcanto\AppData\Local\Temp\1522346740571.png) esta Visível ?

.![52234644133](C:\Users\fcanto\AppData\Local\Temp\1522346735933.png) é maior que hoje?	

![52234649705](C:\Users\fcanto\AppData\Local\Temp\1522346497059.png) é igual a ![52234651891](C:\Users\fcanto\AppData\Local\Temp\1522346518915.png)

![52234649705](C:\Users\fcanto\AppData\Local\Temp\1522346497059.png) esta entre esses numeros 4,8?

![52234644133](C:\Users\fcanto\AppData\Local\Temp\1522346735933.png) esta entre hoje e hoje mais 30 dias?

![52234644133](C:\Users\fcanto\AppData\Local\Temp\1522346735933.png) esta entre hoje e hoje menos 1ano?

###Passo a Passo Parte 3 - Consulta dinamica com SQL

####Criar SQL para trazer os dados de interação

###Passo a Passo Parte 4 - Validações Dinamicas com SQL

####Inserir um sql em um elemento Validação

###Passo a Passo Parte 5 - Reutilizar Casos de testes Compartilhados

####Buscar Casos de Teste por Transação

####Buscar Casos de Teste po Nome

```mermaid
graph TD
USER
subgraph CONSULTA CASO DE TESTE 
A[Informa dados transação]
CARREGAR((CARREGAR))
end
subgraph ELEMENTOS INTERACAO
B[Escolhe os elementos]
ADD
end
subgraph CASO TESTE
CARREGAR_GRID((CARREGAR_GRID))
end
subgraph GRID ELEMENTOS
C[Insere os valores dos elementos]
RODAR((RODAR))
end
subgraph TELA CONCEITO
D[Permanece aberta]
end
    USER-->A
    A-->CARREGAR
    CARREGAR-->B
    B-->ADD
    ADD-->CARREGAR_GRID
    CARREGAR_GRID-->C
    C-->RODAR
    RODAR-->D
classDef green fill:#9f6,stroke:#333,stroke-width:2px;
    class RODAR green
```

