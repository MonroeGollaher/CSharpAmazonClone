import { logger } from '../utils/Logger'
import { AppState } from '../AppState'
import { api } from './AxiosService'
class ItemsService {
  async getItems() {
    try {
      const res = await api.get('api/items')
      console.log(res.data)
      AppState.items = res.data
    } catch (error) {
      logger.error(error)
    }
  }
}
export const itemsService = new ItemsService()
