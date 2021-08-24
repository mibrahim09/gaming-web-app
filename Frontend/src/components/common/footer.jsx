import React from 'react'

const Footer = (props) => {
  return (
    <footer className="s-footer">
      <div className="container-fluid">
        <div className="row justify-content-center">
          <div className="col-md-3 col-sm-6 mt-2">
            <div className="footer-col">
              <h5>About Nova4Gaming</h5>
              <p>
                Nova4Gaming is an unofficial game server for the popular
                multiplayer game. This is just a test release
              </p>
            </div>
          </div>
          <div className="col-md-push-2 col-md-3 mt-2">
            <div className="footer-col">
              <h5>Affiliates</h5>

              <ul className="list-inline social-1">
                <li>
                  <a href="#">ElitePVPers</a>
                </li>
              </ul>
            </div>
          </div>
          <div className="col-md-push-3 col-md-3 col-sm-6 mt-2">
            <div className="footer-col">
              <h5>Chat With Us</h5>
              <p>
                Join our <a href="#">Discord</a> Channel
              </p>
            </div>
          </div>
        </div>
      </div>
    </footer>
  )
}

export default Footer
