#include<iostream>
#include<ctime>
#include<cstdlib>
using namespace std;
int main(){
	srand(time(0));
	string person1,person2;
	int table,multiplication;
	cout<<"Enter the first name of player_1: ";
	cin>>person1;
	cout<<endl<<"\nEnter the first name of player_2: ";
	cin>>person2;
	cout<<endl<<"\nEnter the table for game: ";
	cin>>table;
	int score_1=0,score_2=0;
	clock_t start,end;
	start=clock();
	cout<<endl<<"----------";
	cout<<endl<<person1<<" Turn-----";
	cout<<endl<<"----------";
	for(int i=1;i<=5;i++){
		int x1=rand()%10+1;
		cout<<endl<<"What is the anser of? "<<table<<" * "<<x1<<" = ";
		int ans;
		cin>>ans;
		if(ans==table*x1){
			cout<<endl<<"\t\t\t\t\t-----CORRECT-----";
			score_1++;
		}
		else
		cout<<endl<<"\t\t\t\t\t-----WRONG-----";
	}
	end=clock();
	double time_player1=(end-start)/static_cast<double>(CLOCKS_PER_SEC);
	cout<<endl<<"Score= "<<score_1<<"/5";
	cout<<endl<<"Time= "<<time_player1<<"Seconds";
	cout<<endl<<"----------";
	cout<<endl<<person2<<" Turn-----";
	cout<<endl<<"----------";
	start=clock();
	for(int i=1;i<=5;i++){
		int x1=rand()%10+1;
		cout<<endl<<"What is the anser of? "<<table<<" * "<<x1<<" = ";
		int ans;
		cin>>ans;
		if(ans==table*x1){
			cout<<endl<<"\t\t\t\t\t-----CORRECT-----";
			score_2++;
		}
		else
		cout<<endl<<"\t\t\t\t\t-----WRONG-----";
	}
	end=clock();
	double time_player2=(end-start)/static_cast<double>(CLOCKS_PER_SEC);
	cout<<endl<<"Score= "<<score_2<<"/5";
	cout<<endl<<"Time= "<<time_player2<<"Seconds";
	if(score_1<score_2)
	cout<<endl<<"\t\t\t\t\t"<<"----------"<<person2<<" Won----------";
	else if(score_1>score_2)
	cout<<endl<<"\t\t\t\t\t"<<"----------"<<person1<<" Won----------";
	else if((score_1==score_2)&&(time_player1>time_player2))
	cout<<endl<<"\t\t\t\t\t"<<"----------"<<person2<<" Won----------";
	else if((score_1==score_2)&&(time_player1<time_player2))
	cout<<endl<<"\t\t\t\t\t"<<"----------"<<person1<<" Won----------";
	else
	cout<<endl<<"\t\t\t\t\tTie";
}
