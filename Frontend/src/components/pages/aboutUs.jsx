import React, { Component } from "react";
import { Container, Row, Col } from "react-bootstrap";
import AboutCard from "../common/aboutCard";
class AboutUs extends Component {
  state = {};
  render() {
    return (
      <Container className="fw-light">
        <section className="text-center mt-5 ">
          <p className="fs-1">Meet our team</p>
          <div className="col-lg-6 col-md-8 mx-auto w-30 ">
            <p className="fs-10 text-muted">
              We`d like to get to know you by introducting our team in the
              following page. You'll get to know our developers and our hr team.
            </p>
          </div>
        </section>
        <section>
          <Row>
            <Col xs={6} md={4}>
              <AboutCard
                image="../img/developer.jpg"
                name="Muhammad Ibrahim"
                message=" Greetings! I'm the Engineer behind this website. I hope you
                    enjoy it"
                facebook="https://www.facebook.com/m.ibrahim0xF/"
                instagram="https://www.instagram.com/m.ibrahim09x/"
              />
            </Col>
            <Col xs={6} md={4}>
              <AboutCard
                image="../img/dev2.png"
                name="Ahmed Mohamed"
                message="I'm the HR leader of this project. I'm looking forward to make our team bigger."
                twitter="https://www.facebook.com/m.ibrahim0xF/"
                instagram="https://www.instagram.com/m.ibrahim09x/"
              />
            </Col>
            <Col xs={6} md={4}>
              <AboutCard
                image="../img/dev2.png"
                name="Marwan Mohsen"
                message="I'm happy to be always part of this community. Its been a part of my life for the past few years."
                facebook="https://www.facebook.com/m.ibrahim0xF/"
                twitter="https://www.instagram.com/m.ibrahim09x/"
              />
            </Col>
          </Row>
        </section>
      </Container>
    );
  }
}

export default AboutUs;
