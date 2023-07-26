
import { Component } from '@angular/core';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent {

  purchasePrice: number = 0;
  downPayment: number = 0;
  repaymentTime: number = 1;
  interestRate: number = 0;

  get loanAmount(): number {
    return this.purchasePrice - this.downPayment;
  }

  get monthlyPayment(): number {
    const months = this.repaymentTime * 12;
    const interestRatePerMonth = this.interestRate / 100 / 12;
    const numerator = interestRatePerMonth * Math.pow(1 + interestRatePerMonth, months);
    const denominator = Math.pow(1 + interestRatePerMonth, months) - 1;

    const monthlyPaymentValue = this.loanAmount * (numerator / denominator);
  const formattedMonthlyPayment = Number(monthlyPaymentValue.toFixed(2));
  return formattedMonthlyPayment;
  }
}

