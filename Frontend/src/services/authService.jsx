import jwtDecode from 'jwt-decode'

const keyJWT = 'JWT'

const AuthService = {
  storeJWT(token) {
    localStorage.setItem(keyJWT, token)
  },

  getJwt() {
    return localStorage.getItem(keyJWT)
  },

  removeJwt(token) {
    localStorage.removeItem(keyJWT)
  },

  getUserFromToken() {
    const token = this.getJwt()
    if (token) return jwtDecode(token)
  },
}

export default AuthService
