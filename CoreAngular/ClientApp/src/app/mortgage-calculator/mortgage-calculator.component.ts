import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mortgage-calculator',
  templateUrl: './mortgage-calculator.component.html'
})
export class MortgageCalculatorComponent implements OnInit {
  yearArray: number[] = [];


  constructor()
  {
    for (var i = 1; i <= 25; i++)
    {
      this.yearArray.push(i);
    }
   
  }

  ngOnInit() {
  }

}
