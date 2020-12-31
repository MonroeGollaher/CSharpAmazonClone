<template>
  <div class="newlist-component container-fluid">
    <button class="btn border-0 bg-transparent rounded" data-toggle="modal" data-target="#newListModal">
      <p>New Wish List<i class="fas fa-plus ml-3 text-success"></i></p>
    </button>
    <div class="modal" id="newListModal" tabindex="-1">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">
              New wish list
            </h5>
            <button type="button" class="btn-close bg-transparent border-0 text-danger" data-bs-dismiss="modal" aria-label="Close">
              <i class="far fa-times-circle"></i>
            </button>
          </div>
          <form @submit.prevent="createList" class="p-2">
            <div class="form-group">
              <label for="itemTitle">List title</label>
              <input type="text"
                     class="form-control"
                     id="listTitle"
                     aria-describedby="listTitle"
                     placeholder="What's your list called?"
                     v-model="state.newList.title"
              >
            </div>
            <div class="row justify-content-center align-items-center">
              <label for="image">Published?</label>
              <input class="ml-3" type="checkbox" v-model="state.newList.isPublished">
            </div>
            <div class="row justify-content-center">
              <button type="submit" class="btn btn-primary mb-3">
                Add List
                <i class="fas fa-check ml-2"></i>
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { listsService } from '../services/ListsService'
import { reactive } from 'vue'

export default {
  name: 'NewlistComponent',
  setup() {
    const state = reactive({
      newList: {

      }
    })
    return {
      state,
      createList() {
        listsService.createList(state.newList)
        state.newList = {}
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
