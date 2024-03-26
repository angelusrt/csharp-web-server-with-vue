import api, { Data } from '../api.service';
import { Component, OnInit } from '@angular/core';
import { Alert } from '../components/alert.component';
import { VoteEl } from '../components/voteEl.component';

@Component({
  selector: 'home',
  standalone: true,
  imports: [Alert, VoteEl],
  templateUrl: './homeView.component.html',
  styleUrl: './homeView.component.css'
})
export class HomeView implements OnInit {
  total = 0
  votes = [0, 0, 0]
  pseudonym = ''
  alertShow = false
  alertType = 'success'
  alertMessage = ''
  title = 'frontend-alt'

  public ngOnInit() { this.getVotes() }
  public dismissAlert() { this.alertShow = false }
  public setPseudonym(e: any) { this.pseudonym = e.target.value}
  public async getVotes(){ 
    try {
      let result = await api.get() 
      console.log(result)

      if( 
        typeof result !== "undefined" && result != null && result.length === 3 && 
          typeof result[0] === "number" && typeof result[1] === "number" && typeof result[2] === "number"
      ){
        this.votes = result
        this.total = this.votes[0] + this.votes[1] + this.votes[2]

        console.log('yey votes')
        this.alertShow = true
        this.alertType = 'success'
        this.alertMessage = 'votos acessados'
      } else { throw new Error(''+result) }
    } catch (err) {
      console.log(err)
      this.alertShow = true
      this.alertType = 'error'
      this.alertMessage = 'houve um error ao acessar o banco de dados'
    }
  }
  public async postVote(data: Data){ 
    try {
      if (data.pseudonym === ""){ throw new Error("no-name") }

      let result = await api.post(data) 
      console.log(result)

      if(result !== "Your vote was computed") { throw new Error(result) }

      console.log('yey votes')
      this.alertShow = true
      this.alertType = 'success'
      this.alertMessage = 'voto computado'

    } catch (err) {
      console.log(err)
      this.alertShow = true
      this.alertType = 'error'

      this.alertMessage = (err as Error).message === 'no-name' ? 
        'digite um pseudônimo' : 'houve um error ao acessar o banco de dados'
    }
  }
}
