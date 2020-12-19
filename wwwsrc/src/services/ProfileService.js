import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProfileService {
  async getProfile() {
    try {
      const res = await api.get('/profile')
      AppState.profile = res.data
    } catch (err) {
      logger.log(AppState.profile)
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
}

export const profileService = new ProfileService()
