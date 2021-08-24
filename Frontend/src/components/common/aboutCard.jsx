import React, { Component } from "react";
import { Card } from "react-bootstrap";

class AboutCard extends Component {
  render() {
    const { name, message, image, facebook, instagram, twitter } = this.props;
    return (
      <Card>
        <div style={{ textAlign: 'center' }}>
          <Card.Img
            style={{
              width: "10rem"
            }}
            className="rounded-circle m-3 mx-auto"
            src={image}
          />
        </div>
        <Card.Body>
          <Card.Title>{name}</Card.Title>
          <Card.Text>{message}</Card.Text>
          {facebook && (
            <i
              className="fa fa-facebook-square m-1"
              onClick={() => {
                window.open(facebook, "_blank");
              }}
              aria-hidden="true"
            ></i>
          )}
          {instagram && (
            <i
              className="fa fa-instagram m-1"
              onClick={() => {
                window.open(instagram, "_blank");
              }}
              aria-hidden="true"
            ></i>
          )}
          {twitter && (
            <i
              className="fa fa-twitter m-1"
              onClick={() => {
                window.open(twitter, "_blank");
              }}
              aria-hidden="true"
            ></i>
          )}
        </Card.Body>
      </Card >
    );
  }
}

export default AboutCard;
