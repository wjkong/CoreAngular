import { Component, OnInit } from '@angular/core';
import { InstallPayment } from './installPayment';

@Component({
  selector: 'app-mortgage-calculator',
  templateUrl: './mortgage-calculator.component.html'
})



export class MortgageCalculatorComponent implements OnInit {
  yearArray: number[] = [];
  principal: number = 0;
  rate: number = 0;
  frequency: number = 12;
  amortization: number = 1;
  paymentAmtPerPeriod: number;
  payments: InstallPayment[];
  showDetail: boolean = false;
 

  constructor()
  {
    this.payments = [];

    for (var i = 1; i <= 25; i++)
    {
      this.yearArray.push(i);
    }
   
  }

  ngOnInit() {
  }

  calculate() {
    if (this.frequency > 0 && this.amortization > 0 && this.principal > 0) {
      this.showDetail = true;
      this.payments = [];

      var totalMonthlyCostOfBorrow;
      var freq = [12, 24, 26, 52];
      var freqName = ["Monthly", "Semi-monthly", "Bi-weekly", "Weekly"];

      for (var i = 0; i < freq.length; i++) {
        this.payments[i] = new InstallPayment();

        this.payments[i].frequency = freq[i];
        this.payments[i].freq = freqName[i];
        this.payments[i].installPayment = this.CalculatePayment(this.principal, this.rate, this.amortization, freq[i]);
        this.payments[i].totalPayment = this.CalculateTotalPayment(this.payments[i].installPayment, this.amortization, freq[i]);
        this.payments[i].totalCostOfBorrow = this.CalculateCostOfBorrow(this.principal, this.payments[i].totalPayment);
        this.payments[i].monthlyPayment = this.CalculateMonthlyPayment(this.payments[i].installPayment, freq[i]);

        if (freq[i] == 12)
          totalMonthlyCostOfBorrow = this.payments[i].totalCostOfBorrow;

        this.payments[i].amountSave = totalMonthlyCostOfBorrow - this.payments[i].totalCostOfBorrow;


      }
    }
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
