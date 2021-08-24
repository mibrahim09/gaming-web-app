import React, { Component } from 'react'
import { Container, Card, Row, Col } from 'react-bootstrap'
import DownloadCard from '../common/downloadCard'
import axios from 'axios'
import config from '../../config.json'

class Downloads extends Component {
  state = {
    mega: '#',
    googleDrive: '#',
  }
  apiEndPoint = config.apiEndPoint + 'info'

  async componentDidMount() {
    try {
      const result = await axios.get(this.apiEndPoint)
      if (result.status == 200) {
        const data = result.data.value
        this.setState({ mega: data.mega, googleDrive: data.google })
      }
    } catch {}
  }
  render() {
    return (
      <Container>
        <Row>
          <Col xs={6}>
            <DownloadCard label="MEGA.NZ" link={this.state.mega} />
          </Col>
          <Col xs={6}>
            <DownloadCard label="GOOGLE DRIVE" link={this.state.googleDrive} />
          </Col>
        </Row>
      </Container>
    )
  }
}

export default Downloads
