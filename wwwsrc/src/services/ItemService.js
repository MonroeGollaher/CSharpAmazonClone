import { logger } from '../utils/Logger'
import { AppState } from '../AppState'
import { api } from './AxiosService'
class ItemService {
  async getItems() {
    try {
      const res = await api.get('api/item')
      console.log(res.data)
      AppState.items = res.data
    } catch (error) {
      logger.error(error)
    }
  }
}
export const itemService = new ItemService()
