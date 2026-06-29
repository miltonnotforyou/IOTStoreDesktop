# 🛒 IOT Store - Sistema de Gerenciamento

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-005C84?style=for-the-badge&logo=mysql&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)

> **IOT Store** é um sistema desktop desenvolvido para o gerenciamento completo de um e-commerce focado em dispositivos de Automação Residencial e Internet das Coisas (IoT). Desenvolvido como **Projeto Integrador**, o sistema oferece uma interface moderna e relatórios detalhados para controle de estoque e vendas.

---

## ✨ Funcionalidades

O sistema foi projetado para ser intuitivo e robusto, contando com as seguintes funcionalidades principais:

*   **📦 Cadastro e Gestão de Produtos:** Controle completo de itens com suporte a imagens locais, categorias e marcas.
*   **🔍 Filtros Avançados de Busca:** Consulta inteligente permitindo cruzar dados por:
    *   Categoria e Marca.
    *   Faixa de Preço (Mínimo e Máximo).
    *   Status de Estoque (Normal, Baixo, Zero).
    *   Status de Promoção e Atividade.
*   **📊 Relatórios Gerenciais (PDF):** Geração de relatórios dinâmicos e exportáveis utilizando *Microsoft ReportViewer* (RDLC), com exibição de fotos, cálculo de lucros e detalhamento de estoque.
*   **🎨 Interface Moderna (Dark Mode):** Design agradável implementado com a biblioteca `MaterialSkin`, utilizando esquema de cores Indigo e Pink no tema escuro.

---

## 🛠️ Tecnologias Utilizadas

Este projeto foi construído utilizando as seguintes tecnologias e bibliotecas:

*   **Linguagem:** C#
*   **Plataforma:** .NET Framework (Windows Forms)
*   **Banco de Dados:** MySQL
*   **UI/UX:** [MaterialSkin](https://github.com/IgnaceMaes/MaterialSkin) para componentes visuais
*   **Relatórios:** Microsoft RDLC Report Designer / ReportViewer

---

## 🚀 Como Executar o Projeto

Siga os passos abaixo para rodar o sistema localmente em sua máquina:

### Pré-requisitos
*   Visual Studio (com o pacote de desenvolvimento Desktop com .NET instalado).
*   Servidor MySQL rodando localmente (ex: XAMPP, WampServer ou MySQL Workbench).
*   Extensão *Microsoft RDLC Report Designer* instalada no Visual Studio.

1. **Clone o repositório:**
git clone [https://github.com/SEU_USUARIO/iot-store.git](https://github.com/SEU_USUARIO/iot-store.git)
    
2. **Configure o Banco de Dados:**
Importe o arquivo script_banco.sql (disponível na pasta /database) no seu gerenciador MySQL.
Abra o arquivo classConexao.cs (ou similar) no Visual Studio e ajuste a Connection String com seu usuário e senha do MySQL.

3.**Restaure os Pacotes NuGet:**
Clique com o botão direito na Solução dentro do Visual Studio e selecione Restore NuGet Packages (para baixar o MaterialSkin e o ReportViewer)

4.**Compile e Execute:**
Pressione F5 ou clique em Iniciar para rodar a aplicação.

📸 Telas do Sistema:

<img width="1365" height="720" alt="image" src="https://github.com/user-attachments/assets/d53f112f-0184-44ca-8423-285dc6314a02" />

<img width="1361" height="689" alt="image" src="https://github.com/user-attachments/assets/22384861-1ca5-4e94-b327-853cfc93df56" />

<img width="1359" height="687" alt="image" src="https://github.com/user-attachments/assets/600a7975-60cd-4be3-9b9b-b30e92d1bc83" />

<img width="1361" height="691" alt="image" src="https://github.com/user-attachments/assets/b8449874-bdeb-4632-9729-244e684b08c5" />



💡 **Aprendizados e Desafios:**

Durante o desenvolvimento deste Projeto Integrador, grandes conceitos de programação orientada a objetos (POO) e arquitetura de software foram aplicados. Os principais desafios superados envolveram:A integração entre consultas SQL complexas e o DataSet tipado do C#.  O mapeamento e exibição dinâmica de imagens externas dentro de relatórios RDLC.  Feito com ☕ e muito código por Milton Silva!




   
