#include<iostream>
#include<cstdlib>
#include<ctime> 
using namespace std;
int main(){
	srand(time(0));
	string p1,p2;
	cout<<"Player-1 First Name: ";
	cin>>p1;
	cout<<"player_2 first name: ";
	cin>>p2;
	int score_1=0,score_2=0;
	clock_t start,end;
	start=clock();
	cout<<"----------";
	cout<<endl<<p1<<" Turn-----";
	cout<<"\n----------";
	for(int i=1;i<=5;i++){
	int x1=rand()%100+1;
	int x2=rand()%100+1;
	if(x1<x2)
	swap(x1,x2);
	cout<<"\nWhat is the answer of: "<<x1<<"-"<<x2<<"=";
	int ans;
	cin>>ans;
	if(ans==(x1-x2)){
		cout<<"\t\t\t\t\t-----CORRECT-----";
		score_1++;
	}
	else
	cout<<"\t\t\t\t\t-----WRONG-----";}
	end=clock();
	cout<<"\n----------";
	cout<<endl<<p1<<" SCORE-----";
	cout<<"\n----------";
	double time_player1=(end-start)/static_cast<double>(CLOCKS_PER_SEC);
	cout<<endl<<"Score="<<score_1<<"/5";
	cout<<endl<<"Time= "<<time_player1<<"Seconds";
	cout<<endl<<p2<<" Turn-----";
	start=clock();
	for(int i=1;i<=5;i++){
	int x1=rand()%100+1;
	int x2=rand()%100+1;
	if(x1<x2)
	swap(x1,x2);
	cout<<"\nWhat is the answer of: "<<x1<<"-"<<x2<<"=";
	int ans;
	cin>>ans;
	if(ans==(x1-x2)){
		cout<<"\t\t\t\t\t-----CORRECT-----";
		score_2++;
	}
	else
	cout<<"\t\t\t\t\t-----WRONG-----";}
	end=clock();
	cout<<"\n----------";
	cout<<endl<<p2<<" SCORE-----";
	cout<<"\n----------";
	double time_player2=(end-start)/static_cast<double>(CLOCKS_PER_SEC);
	cout<<endl<<"Score="<<score_2<<"/5";
	cout<<endl<<"Time= "<<time_player2<<"Seconds";
	if(score_1<score_2)
	cout<<endl<<"\t\t\t\t\t"<<"----------"<<p2<<" Won----------";
	else if(score_1>score_2)
	cout<<endl<<"\t\t\t\t\t"<<"----------"<<p1<<" Won----------";
	else if((score_1==score_2)&&(time_player1>time_player2))
	cout<<endl<<"\t\t\t\t\t"<<"----------"<<p2<<" Won----------";
	else if((score_1==score_2)&&(time_player1<time_player2))
	cout<<endl<<"\t\t\t\t\t"<<"----------"<<p1<<" Won----------";
	else
	cout<<endl<<"\t\t\t\t\t----------Tie----------";
	return 0;
}
