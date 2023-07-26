import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-url-shorten',
  templateUrl: './url-shorten.component.html',
  styleUrls: ['./url-shorten.component.css']
})
export class UrlShortenComponent {
  myForm = new FormGroup({
    url : new FormControl()
  })
final!:any

  shortenUrl()
  {
    const shortenUrl=this.myForm.value.url
    this.final=shortenUrl.split('/', 3).slice(-1)
  }

  copy()
  {
    navigator.clipboard.writeText(this.final);
    alert('Text copied to clipboard')
  }
}
