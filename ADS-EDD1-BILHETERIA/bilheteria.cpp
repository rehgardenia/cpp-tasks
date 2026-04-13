#include<iostream>
	#include <iomanip> 
	#include <locale.h>
	
	using namespace std;
	
	const int  fileiras = 15;
	const int poltronas = 40;
	    
	void exibirMapa(char assento[fileiras][poltronas]){
		// COR
	    const string VERDE = "\033[32m";
    	const string VERMELHO = "\033[31m";
    	const string RESET = "\033[0m";
    	// MAPA 
	    cout << "------------------------------------------------------------------------------------" << endl;
	    cout << " Mapa do Teatro " << endl;
	    cout << "------------------------------------------------------------------------------------" << endl;
	    for(int i=0; i < fileiras; i++){
	        cout << setw(3)<< i +1 << "|";
	        for(int j =0; j< poltronas; j++){
	        	if(assento[i][j] == '*'){
					cout<< VERDE << assento[i][j] <<RESET << "|";
				}
				else {
					cout<< VERMELHO << assento[i][j] <<RESET << "|";
				}
	            
	        }
	        cout << endl;
	    }
		cout << "------------------------------------------------------------------------------------" << endl;
	    cout << VERDE << "'*'  representa lugar vago"<< RESET <<endl;
	    cout << VERMELHO << "'#' representa lugar ocupado" << RESET << endl;
		cout << "------------------------------------------------------------------------------------" << endl;
	}
	int main()
	{
		setlocale(LC_ALL, "");
	  // Criando Matriz de Poltronas
	  
	    char assento[fileiras][poltronas];
	    
	    for(int i=0; i < fileiras; i++){
	        for(int j =0; j< poltronas; j++){
	            assento[i][j] = '*';
	        }
	    }
	    
	    // Variaveis
		float valor = 0;
  		int qtdReservado =0;
 	 	int op;
 	 	
 	    // Opções
	    do{
	    	// Variaveis
			string hr = "------------------------------------";
			// Menu
			cout << "\033[35m";
		    cout << hr << endl;
		    cout << "Bem Vindo! A Bilheteria IF!" << endl;
		    cout << hr << endl;
		    cout << left << setw(5) << "0." << "Finalizar" << endl;
		    cout << left << setw(5) << "1." << "Reservar poltrona" << endl;
		    cout << left << setw(5) << "2." << "Mapa de ocupação" << endl;
		    cout << left << setw(5) << "3." << "Faturamento" << endl;
		    cout << hr << endl;
		    cout << "\033[0m";
		    cout << "Selecione uma opção: ";
		   
	  	    cin >> op;
	    
			if ( op == 1){
				// Reservar poltrona
			    cout << hr << endl;
			    cout << "Opção " << op<< " :  Reservar Poltrona" <<endl;
		   	    cout << hr << endl;
		   	    cout << "Fileiras 01 a 05:          R$ 50,00" << endl;
    			cout << "Fileiras 06 a 10:          R$ 30,00" << endl;
				cout << "Fileiras 11 a 15:          R$ 15,00" << endl;
	  	  		cout << hr << endl;
		   	    
		   	    int fila = 0, col = 0;
			    cout << "Fileira: ";
			    cin >> fila;
			    cout << "Poltrona: ";
			    cin>> col;
		  		
			    
				if(assento[fila][col] == '*'){
			    	if(fila + 1 <= 5){
						valor += 50;
					}
					else if ( fila + 1 <= 10){
						valor += 30;
					}
					else {
						valor += 15;
					}
					qtdReservado++;
					assento[fila][col] = '#';
				
					cout<< "Assento "<< fila << ":"<< col<< " reservado com sucesso!" << endl;
				}
				else{
					cout<< "Assento Ocupado. Tente Novamente!" << endl;
					
				}
			}
	 		else if (op == 2){
	 			// Mapa de ocupação
		 		exibirMapa(assento);
		 		
			}
			 else if (op == 3){
			 	// Faturamento
			 	cout << hr << endl;
			    cout << "Opção " << op<< " :  Faturamento" <<endl;
		   	    cout << hr << endl;
		   	    cout << "Qtd de lugares ocupados: "  << setw(20) << qtdReservado << endl;
		   	    cout << "Valor da bilheteria: "<< setw(4)<< "R$ " << valor << setprecision(2) << endl ;
			 }
			 else{
			 	 cout << "Opção não encontrada!"<< endl;
			 }
		} while (op != 0);
	    
	    return 0;
	}