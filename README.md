# ProtocoloNFe
Aplicativo linha de comando com o intuito de consultar e adicionar as informações do protocolo da NFe emitida.
# Por que?
Ao emitir uma nota fiscal, nem sempre a informação do protocolo é retornada de imediato após a emissão, podendo o xml
gerado ficar com o status de emissão correto, porém sem as informações do protocolo, o que impede esses documentos de serem 
apurados por sistemas contábil/fiscal.

O protocoloNFe implementa a consultaNFe fornecida pelos serviços da Sefaz Nacional, consultando o documento via chave de acesso e atualizando o xml original 
com as informações do processamento da nota, adicionando o cabeçalho procNFe e Roda-pé protNFe.

Obs.: atualmente funcionando apenas para o modelo 65 da NFe, versões ( 3.10 e 4.00 ).
