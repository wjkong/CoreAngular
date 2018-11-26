import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mortgage-calculator',
  templateUrl: './mortgage-calculator.component.html'
})
export class MortgageCalculatorComponent implements OnInit {
  yearArray: number[] = [];
  principal: number;
  rate: number;
  frequency: number;
  amortization: number;
  paymentAmtPerPeriod: number;

  constructor()
  {
    for (var i = 1; i <= 25; i++)
    {
      this.yearArray.push(i);
    }
   
  }

  ngOnInit() {
  }

  calculate() {
    this.paymentAmtPerPeriod = this.CalculatePayment(this.principal, this.rate, this.amortization, this.frequency);

    alert("Le" + this.paymentAmtPerPeriod);
  }

  CalculatePayment(principal, rate, amortization, frequency) {
    var paymentPerPeriod = 0.00;
    var extraPaymentPerPeriod = 0.00;

    if (frequency == 28 || frequency == 56) {
      var monthlyPaymentAmt = this.CalculatePayment(principal, rate, amortization, 12);

      frequency = frequency == 28 ? 26 : 52;

      extraPaymentPerPeriod = monthlyPaymentAmt / frequency;
    }

    rate = rate / (frequency * 100);
    amortization = amortization * frequency;

    if (rate == 0)
      paymentPerPeriod = principal / amortization;
    else
      paymentPerPeriod = (principal * rate) / (1 - Math.pow(1 + rate, -amortization));

    paymentPerPeriod += extraPaymentPerPeriod;
    paymentPerPeriod = paymentPerPeriod;

    return paymentPerPeriod;
  }

  CalculateMonthlyPayment(paymentPerPeriod, paymentFrequency) {
    var monthlyPayment = 0.00;

    if (paymentFrequency == 28)
      paymentFrequency = 26;
    else if (paymentFrequency == 56)
      paymentFrequency = 52;

    monthlyPayment = paymentPerPeriod * paymentFrequency / 12;
    monthlyPayment = monthlyPayment;

    return monthlyPayment;
  }

  CalculateTotalPayment(paymentPerPeriod, amortization, paymentFrequency) {
    var totalPayment = 0.00;

    if (paymentFrequency == 28)
      paymentFrequency = 26;
    else if (paymentFrequency == 56)
      paymentFrequency = 52;

    totalPayment = paymentPerPeriod * amortization * paymentFrequency;
    totalPayment = totalPayment;

    return totalPayment;
  }

  CalculateCostOfBorrow(principal, totalPayment) {
    var costOfBorrow = 0.00;

    costOfBorrow = totalPayment - principal;
    costOfBorrow = costOfBorrow;

    return costOfBorrow;
  }

}
