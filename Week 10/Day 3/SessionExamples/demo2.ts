function  f1() 
{
	console.log("Welcome to TypeScript");
}

function   greeting(uname:string):void
{
	var str:string  = "Welcome to  "	+ uname;
	console.log(str);
}

function  sum(x:number,  y:number): number
{
	var z:number;
	z  = x + y;
	return z;	
}

f1();
greeting("Scott");
var n:number   = sum(10,20);
console.log("Sum Result   : "  + n);