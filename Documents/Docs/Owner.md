A entidade Owner é a responsável por ser a proprietária de um estoque dentro do domínio. Isso quer dizer que, todo o fluxo da armazenagem será indexado em um Owner, ele vai ser o dono dos produtos que serão armazenados. Na minha visão, um proprietário (owner) sozinho não é nada! Para o fluxo do estoque rodar, o proprietário precisa de um fornecedor, um cliente e uma transportadora, então cada uma dessas "entidades" citadas aqui foram alocadas como sendo dependentes do proprietário e ele mesmo sendo dependente delas.

Para um proprietário existir, será necessário que ele tenha pelo menos uma entidade de cada: um fornecedor para as mercadorias dele, um transportador para transportar as entradas e saídas das mercadorias e um cliente, que será repensável por comprar as mercadorias de um proprietário. É uma regra obrigatória, sempre terá que existir ao menos um de cada um, deles.

```json
{
   "code":"1123",
   "name":"Tegma Serviços LTDA",
   "document":"1212121",
   "customers":[
      {
         "code":"AURORA",
         "name":"Aurora supermercado",
         "document":"1212121"
      }
   ],
   "carriers":[
      {
         "code":"TRANSP",
         "name":"Transportador de teste",
         "document":"1212121"
      }
   ],
   "suppliers":[
      {
         "code":"SUPP",
         "name":"Fornecedor de teste",
         "document":"1212121"
      }
   ]
}
```