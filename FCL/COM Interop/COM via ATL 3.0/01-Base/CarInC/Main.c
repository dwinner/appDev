/* defines */
#define MAX_NAME_LENGTH		100
#define MAX_SPEED			500


/* includes */
#include <stdio.h>
#include <string.h>


/* the CAR struct */
struct CAR
{
	char	petName[MAX_NAME_LENGTH];
	int		maxSpeed;
	int		currSpeed;
};


/* Prototypes */
void DisplayCarStats(struct CAR c);
void CreateACar(struct CAR* c);
void SpeedUp(struct CAR* c);


/* Program Entry Point */
void main(void)
{
	/* Make a car type */
	struct CAR myCar;

	printf("***********************************\n");
	printf("The Amazing Car Application via C\n");
	printf("***********************************\n\n");
	
	/* Go create a car. */
	CreateACar(&myCar);

	/* Display new car info*/
	DisplayCarStats(myCar);

	/* Speed up until engine block cracks */
	while(myCar.currSpeed <= myCar.maxSpeed)
		SpeedUp(&myCar);
	
	printf("\n%s has blown up!  Lead foot!\n", myCar.petName);

}	/*  End of main */



/* Take a CAR struct and show the field values */
void DisplayCarStats(struct CAR c)
{
	printf("***********************************\n");	
	printf("Your car is called: %s\n", c.petName);
	printf("It does up to %d\n", c.maxSpeed );
	printf("***********************************\n\n");	
}


/* This method creates (fills) a CAR struct. */
void CreateACar(struct CAR* c)
{

	char	buffer[MAX_NAME_LENGTH];
	int	spd = 0;
	memset(c, 0, sizeof(struct CAR));

	printf("Please enter a pet-name for your car: ");
	gets(buffer); 	// Read in a string & set field.
	
	// Could check strlen() against MAX_LENGTH.
	strcpy(c->petName, buffer);

	do 	// Be sure speed isn't beyond MAX_SPEED
	{		
		printf("Enter the max speed of this car: ");
		scanf("%d", &spd);
	}while(spd > MAX_SPEED);

	// Set other fields.
	c->maxSpeed = spd;
	c->currSpeed=0;		

}


/* Increase the CAR by 10 MPH 
   and print current speed*/
void SpeedUp(struct CAR* c)
{
	if(c->currSpeed <= c->maxSpeed)
	{
		c->currSpeed = c->currSpeed + 10;
		printf("\tSpeed is: %d\n", c->currSpeed);
	}
}
	