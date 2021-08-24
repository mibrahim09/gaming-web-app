import React, { Component } from "react";
import { Container, Row, Col } from "react-bootstrap";
import { Link } from "react-router-dom";
class Ranks extends Component {
  state = {};
  render() {
    return (
      <Container className="mt-5">
        <Row>
          <Col xs={4}>
            <div
              className="btn-group-vertical"
              role="group"
              aria-label="Vertical radio toggle button group"
            >
              <input
                type="radio"
                className="btn-check"
                name="vbtn-radio"
                id="vbtn-radio1"
                autoComplete="off"
              />
              <label className="btn btn-outline-danger" htmlFor="vbtn-radio1">
                Radio 1
              </label>
              <input
                type="radio"
                className="btn-check"
                name="vbtn-radio"
                id="vbtn-radio2"
              />
              <label className="btn btn-outline-danger" htmlFor="vbtn-radio2">
                Radio 2
              </label>
              <input
                type="radio"
                className="btn-check"
                name="vbtn-radio"
                id="vbtn-radio3"
              />
              <label className="btn btn-outline-danger" htmlFor="vbtn-radio3">
                Radio 3
              </label>
            </div>
          </Col>
          <Col xs={6}>
            <Col xs={3} className="mb-2">
              <Link className="btn btn-primary" to="/books/new">
                New Book
              </Link>
            </Col>{" "}
            <table className="table">
              <thead>
                <tr>
                  <th scope="col">#</th>
                  <th scope="col">First</th>
                  <th scope="col">Last</th>
                  <th scope="col">Handle</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <th scope="row">1</th>
                  <td>Mark</td>
                  <td>Otto</td>
                  <td>@mdo</td>
                </tr>
                <tr>
                  <th scope="row">2</th>
                  <td>Jacob</td>
                  <td>Thornton</td>
                  <td>@fat</td>
                </tr>
                <tr>
                  <th scope="row">2</th>
                  <td>Jacob</td>
                  <td>Thornton</td>
                  <td>@fat</td>
                </tr>
                <tr>
                  <th scope="row">2</th>
                  <td>Jacob</td>
                  <td>Thornton</td>
                  <td>@fat</td>
                </tr>
                <tr>
                  <th scope="row">2</th>
                  <td>Jacob</td>
                  <td>Thornton</td>
                  <td>@fat</td>
                </tr>
                <tr>
                  <th scope="row">2</th>
                  <td>Jacob</td>
                  <td>Thornton</td>
                  <td>@fat</td>
                </tr>
                <tr>
                  <th scope="row">3</th>
                  <td colSpan="2">Larry the Bird</td>
                  <td>@twitter</td>
                </tr>
              </tbody>
            </table>
            <nav aria-label="Page navigation example">
              <ul className="pagination">
                <li className="page-item">
                  <a className="page-link" href="#">
                    Previous
                  </a>
                </li>
                <li className="page-item">
                  <a className="page-link" href="#">
                    1
                  </a>
                </li>
                <li className="page-item">
                  <a className="page-link" href="#">
                    2
                  </a>
                </li>
                <li className="page-item">
                  <a className="page-link" href="#">
                    3
                  </a>
                </li>
                <li className="page-item">
                  <a className="page-link" href="#">
                    Next
                  </a>
                </li>
              </ul>
            </nav>
          </Col>
        </Row>
      </Container>
    );
  }
}

export default Ranks;
