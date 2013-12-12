function dw(int index, int value) {
}

function dr(int index, string type) {
}


visiable | name | index | value
glob	    df		0   	0
a			da		1,2,3	1='a',2='b',3='c'	
a			s		4		0
a			e		5		0
b			s		6		0
b			e		7		0

int M[] = [0,'a','b','c',0,0,0,0];

int df; //# fw(0,0);

void func a(int s, int e){ //# fw(1,0); fw(2,0); // void func a() 
	string da = "abc";
	da += 's';
	df = s + e; // fw(0, fr(1)+fr(2))
}

void func b(int s, int e){ //# fw(3,0); fw(4,0); // void func b()
	df = s + e; // fw(3, fr(3)+fr(4))
}


void main() {
	a(3,5); // wr(1, 3); wr(2, 5); a();
	
}