import { logger } from '../utils/Logger'
import { AppState } from '../AppState'
import { api } from './AxiosService'

class ListsService {
  async getLists() {
    try {
      const res = await api.get('api/lists')
      console.log(res.data)
      AppState.lists = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async createList(listData) {
    try {
      await api.post('api/lists', listData)
      this.getLists()
    } catch (error) {
      logger.error(error)
    }
  }
}

export const listsService = new ListsService()
