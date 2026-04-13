#include <iostream>
#include <locale.h>
#include <string>

using namespace std;

class Data 
{
	private:
	   int dia;
   	   int mes;
	   int ano;
     public:
     	Data(int dia, int mes, int ano)
     	{
		 	this->dia = dia;
		 	this->mes = mes;
		 	this->ano = ano;
        }
        Data()
        {
			this->dia = 0;
			this->mes = 0;
			this->ano = 0;
		}
		// void setDia(int dia)
		// {
		// 	this->dia = dia;
		// }
		// void setMes(int mes)
		// {
		// 	this->mes = mes;
		// }
		// void setAno(int ano)
		// {
		// 	this->ano = ano;			
		// }
		// int getDia()
		// {
		// 	return this->dia;
		// }
		// int getMes()
		// {
		// 	return this->mes;
		// }
		int getAno()
		{
			return this->ano;
		}
		string getData()
		{
			string sdia = to_string(this->dia);
            string smes = to_string(this->mes);
            string sano = to_string(this->ano);
        	return sdia.insert(0, 2-sdia.size(), '0') + "/" + 
	               smes.insert(0, 2-smes.size(), '0') + "/" + 
		           sano;
		}
		Data* dia_seguinte()
		{
			int ultimoDiaDoMes[12] = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
		    Data *d1 = new Data(this->dia, this->mes, this->ano);
		   	
		   	if (d1->ano%4 == 0)
			   	ultimoDiaDoMes[1]++; 
		   
		   d1->dia++;
		   if (d1->dia > ultimoDiaDoMes[d1->mes-1])
		   {
		   	d1->dia = 1;
		   	d1->mes++;
		   	if (d1->mes>12)
			   {
			   	d1->mes = 1;
			   	d1->ano++;
			   }
		   }	
		   return d1;
	}
};

class Contato {

    private:
        string email;
        string nome;
        string telefone;
        Data dtNasc;
    public:
        Contato(string e, string nm , string tel, Data dt){
            this-> email = e ;
            this-> nome = nm ;
            this-> telefone = tel ;
            this-> dtNasc = dt ;
        }
        Contato (){}
        // Setters
        void setEmail(string e ){
            this.email = e;
        }
        void setNome(string n){
            this.nome = n;
        }
        void setTelefone(string tel){
            this.telefone = tel;
        }
        void setDtNasc(Data dt){
            this.dtNasc = dt;
        }
        // Getters
        string getEmail(){
            return this.email;
        }
        string getNome(){
            return this.nome;
        }
        string getTelefone(){
            return this.telefone;
        }
        Data getDtNasc(){
            return this.dtNasc;
        }

        int idade(){
            return 2026 - dtNasc.getAno();
        }
        void exibirContato() {
            cout << "--------------------------" << endl;
            cout << " Nome:     " << this->nome << endl;
            cout << " E-mail:   " << this->email << endl;
            cout << " Telefone: " << this->telefone << endl;
            cout << " Idade:    " << this->idade() << " anos" << endl;
            cout << "--------------------------" << endl;
        }
};

int main(int argc, char** argv)
{
	setlocale(LC_ALL, "");
    
    // Criando estrutura para 5 contatos
    Contato contatos[5];
    string nome, email, tel;
    int d, m, a;

    cout << "### Cadastro de Contatos ###" << endl;

    for(int i = 0; i < 5; i++) {
        cout << "\nContato " << i + 1 << ":" << endl;
        cout << "Nome: ";
        cin >> nome;
        cout << "E-mail: ";
        cin >> email;
        cout << "Telefone: ";
        cin >> tel;
        cout << "Data de Nasc. (dia mes ano separados por espaco): ";
        cin >> d >> m >> a;

        // Criamos o contato e armazenamos no vetor
        contatos[i] = Contato(email, nome, tel, Data(d, m, a));
    }

    cout << "\n\n### Lista de Contatos Cadastrados ###" << endl;
    for(int i = 0; i < 5; i++) {
        contatos[i].exibirContato();
    }

    return 0;
}

