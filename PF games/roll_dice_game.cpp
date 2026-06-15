#include<iostream>
#include<ctime>
#include<cstdlib>
using namespace std;
int main(){
	string person1,person2;
	int totalscore1,totalscore2;
	int score_1=0,score_2=0;
	srand(time(0));
	cout<<"Enter the first name of the player: ";
	cin>>person1;
	cout<<endl<<"Enter the first name of the player: ";
	cin>>person2;
	char character;
	for(int i=1;i<=10;i++){
		cout<<endl<<"\nEnter any key to dice the role: ";
		cin>>character;
		int dice=rand()%6+1;
		cout<<"\nYour point in this turn is: "<<dice<<endl;
		score_1+=dice;
    }
	cout<<endl<<"\n\n\t\t\t----------The score of player "<<person1<<" is "<<score_1<<"----------";
	for(int i=1;i<=10;i++){
		cout<<endl<<"\nEnter any key to dice the role: ";
		cin>>character;
		int dice=rand()%6+1;
		cout<<endl<<"\nYour point in this turn is: "<<dice;
		score_2+=dice;
	}
	cout<<endl<<"\n\n\t\t\t----------The score of player "<<person2<<" is "<<score_2<<"----------";
	if(score_1>score_2)
	cout<<endl<<"\n\n\t\t\t\t\t----------"<<person1<<" WON----------";
	else if(score_1<score_2)
	cout<<endl<<"\n\n\t\t\t\t\t----------"<<person2<<" WON----------";
	else if(score_1==score_2)
	cout<<endl<<"\t\t\t\t\t\t\t-----TIE-----";
	else
	cout<<endl;
	return 0;
}
