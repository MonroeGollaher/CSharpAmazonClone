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

  async setActiveList(listId) {
    try {
      const res = await api.get('api/lists/' + listId)
      AppState.activeList = res.data
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

  async deleteList(id) {
    try {
      await api.delete('api/lists/' + id)
      logger.log('list deleted')
      this.getLists()
    } catch (error) {
      logger.error(error)
    }
  }

  async editList(editData, id) {
    try {
      await api.put('api/lists/' + id, editData)
      logger.log('edited')
      this.getLists()
    } catch (error) {
      logger.error(error)
    }
  }
}

export const listsService = new ListsService()
