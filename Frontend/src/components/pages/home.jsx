import React, { Component } from 'react'
import { Container } from 'react-bootstrap'
import config from '../../config.json'
import axios from 'axios'
class Home extends Component {
  state = {
    onlinePlayers: 'LOADING',
    serverStatus: 'LOADING',
    lastGuildWarWinner: 'LOADING',
    lastTwinCityWinner: 'LOADING',
    lastCounterClockWinner: 'LOADING',
  }

  apiEndPoint = config.apiEndPoint + 'statistics'

  async componentDidMount() {
    try {
      const result = await axios.get(this.apiEndPoint)
      if (result.status == 200) {
        const data = result.data
        this.setState(data)
      }
    } catch {}
  }
  getServerState() {
    const currentState = this.state.serverStatus
    if (currentState == 'ONLINE')
      return (
        <span>
          <span style={{ color: 'green' }}>{currentState} </span>with{' '}
          <span style={{ color: 'green' }}>{this.state.onlinePlayers}</span>{' '}
          players online
        </span>
      )
    return <span style={{ color: 'lightred' }}>{currentState}</span>
  }
  render() {
    return (
      <Container>
        <Container className="fw-light text-center">
          <section className="mt-5">
            <p className="fs-1">Welcome to Nova4Gaming</p>
            <div className="col-lg-6 col-md-8 mx-auto w-30 ">
              <p className="fs-10">
                Start playing now and become one of our warriors right now. The
                server is now {this.getServerState()}.
              </p>
              <p>
                The last guildwar was dominated by{' '}
                <span style={{ color: 'red' }}>
                  {this.state.lastGuildWarWinner}
                </span>
              </p>
              <p>
                The last twincity war winner is{' '}
                <span style={{ color: 'orange' }}>
                  {this.state.lastTwinCityWinner}
                </span>
              </p>
              <p>
                LastCounterClock winner is{' '}
                <span style={{ color: 'blue' }}>
                  {this.state.lastCounterClockWinner}
                </span>
              </p>
            </div>
          </section>
          <button className="btn btn-primary p-2">Get started</button>
        </Container>
      </Container>
    )
  }
}

export default Home
