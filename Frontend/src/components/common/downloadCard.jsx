import React, { Component } from 'react'
import { Card, Container } from 'react-bootstrap'
const DownloadCard = (props) => {
  return (
    <Card className="card-group">
      <Card.Body>
        <Card.Title className="card-title mb-3">{props.label}</Card.Title>
        <Card.Text>
          Client Size:{' '}
          <span style={{ color: 'red'}}>400MB</span>
        </Card.Text>{' '}
        <Card.Text>
          Client Version:{' '}
          <span style={{ color: 'red' }}>1000</span>
        </Card.Text>{' '}
        <Container className="text-center">
          <button
            className="btn btn-primary btn-lg"
            onClick={() => window.open(props.link, '_blank')}
          >
            DOWNLOAD
          </button>
        </Container>
      </Card.Body>
    </Card>
  )
}

export default DownloadCard
